using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NmapXmlParser;
using System.Xml.Serialization;
using System.IO;

// Project use word interop and NmapXmlParser by kamiizumi


// Word interop
// In project, right click references -> Add references -> COM -> search word -> Microsoft Word 16.0 Object Library
// To work computer need some form of office
// in this version, work with word 2019

// NmapXmlParser 
// NmapXmlParser by kamiizumi
// Tools -> NuGet Package Manager -> Manage NuGet Package for Solution ... -> Browse -> search NmapXmlParser -> install

// BlackList RPC


namespace Final__Convert_NmapXML_To_Word_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // get file path of the xml file
        private void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string filePath = openFileDialog.FileName;
                textBox_FilePath.Text = filePath;
            }
        }
        
        private void btn_Convert_Click(object sender, EventArgs e)
        {
            textBox_Status.Text = "Reading XML Data";
            List<Machine> list_Machines = Convert_XML_To_List(textBox_FilePath.Text);
            textBox_Status.Text = "Creating Word Document";
            CreateDocument(list_Machines, textBox_FilePath.Text);
        }
        
        private List<Machine> Convert_XML_To_List(string inputFilePath)
        {
            
            var xmlSerializer = new XmlSerializer(typeof(nmaprun));
            var result = default(nmaprun);
            
            using (var xmlStream = new StreamReader(inputFilePath))
            {
                result = xmlSerializer.Deserialize(xmlStream) as nmaprun;
            }

            List<Machine> list_Machines = new List<Machine>();

            for (int i = 1; i < result.Items.Length; i++)
            {
                // Lấy địa chỉ IP của host hiện tại
                NmapXmlParser.host host = (host)result.Items[i];
                Machine machine = new Machine(host.address.addr);

                // Item[1] chứa tập tất cả các cổng
                NmapXmlParser.ports list_ports = (ports)host.Items[1];

                List<OpenPort> list_OpenPort = new List<OpenPort>();
                // lấy thông tin của các cổng đang mở
                string listPort = "";
                if (list_ports.port != null)
                {
                    foreach (port port in list_ports.port)
                    {
                        if (port.state.state1 == "open")
                        {
                            string output = "";
                            if (string.IsNullOrEmpty(port.service.product) || port.service.product == "null")
                                output = "null";
                            else
                            {
                                output = port.service.product;
                                if (string.IsNullOrEmpty(port.service.version) == false && port.service.version != "null")
                                    output = output + " " + port.service.version;
                            }
                            if (output != "null" && output.Contains("RPC") == false)
                            {
                                if (listPort == "")
                                {
                                    listPort = listPort + port.portid;
                                }
                                else
                                {
                                    listPort = listPort + ", " + port.portid;
                                }

                                bool is_exist = false;
                                foreach (OpenPort port_x in list_OpenPort)
                                {
                                    if (port_x.serviceName == output)
                                    {
                                        is_exist = true;
                                        if (string.IsNullOrEmpty(port_x.portID))
                                        {
                                            port_x.portID = port.portid;
                                        }
                                        else
                                        {
                                            port_x.portID = port_x.portID + ", " + port.portid;
                                        }
                                    }


                                }
                                if (is_exist == false)
                                {
                                    OpenPort new_OpenPort = new OpenPort(port.portid, output);
                                    list_OpenPort.Add(new_OpenPort);
                                }
                            }
                        }
                    }
                    machine.list_OpenPorts = list_OpenPort;
                    machine.OpenPorts_Ascending = listPort;
                    list_Machines.Add(machine);
                }
            }
            return list_Machines;
        }
    
        private void CreateDocument(List<Machine> list_Machines, string filePath)
        {
            try
            {
                //Create an instance for word app  
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application  
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                winword.Visible = false;

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                //Create a new document  
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //adding text to document  
                document.Content.SetRange(0, 0);
                foreach(Machine machine in list_Machines)
                {
                    Microsoft.Office.Interop.Word.Paragraph MachineIP = document.Content.Paragraphs.Add(ref missing);
                    MachineIP.Range.Text = "IP = " + machine.IP;
                    MachineIP.Range.Font.Name = "times new roman";
                    MachineIP.Range.InsertParagraphAfter();

                    Microsoft.Office.Interop.Word.Paragraph MachineOpenPort_Ascending = document.Content.Paragraphs.Add(ref missing);
                    MachineOpenPort_Ascending.Range.Text = machine.OpenPorts_Ascending;
                    MachineOpenPort_Ascending.Range.Font.Name = "times new roman";
                    MachineOpenPort_Ascending.Range.InsertParagraphAfter();



                    //Create a 2Xn table and insert some dummy record  
                    Table firstTable1 = document.Tables.Add(MachineIP.Range, machine.list_OpenPorts.Count + 1, 2, ref missing, ref missing);
                    firstTable1.Borders.Enable = 1;

                    int i = -1;
                    foreach (Row row in firstTable1.Rows)
                    {
                        row.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                        foreach (Cell cell in row.Cells)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Width = winword.Application.CentimetersToPoints(3.63F);
                                cell.Height = winword.Application.CentimetersToPoints(0.51F);
                            }
                            else
                            {
                                cell.Width = winword.Application.CentimetersToPoints(9.84F);
                                cell.Height = winword.Application.CentimetersToPoints(0.51F);
                            }

                            //Header row  
                            if (cell.RowIndex == 1)
                            {
                                if(cell.ColumnIndex == 1)
                                {
                                    cell.Range.Text = "Port";
                                }    
                                else
                                {
                                    cell.Range.Text = "Service";
                                }    
                                cell.Range.Font.Bold = 1;
                                //other format properties goes here  
                                cell.Range.Font.Name = "times new roman";
                                cell.Range.Font.Size = 14;
                                cell.Range.ParagraphFormat.SpaceAfter = 1F;
                                cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            //Data row  
                            else
                            {
                                if (cell.ColumnIndex == 1)
                                    cell.Range.Text = machine.list_OpenPorts[i].portID;
                                else
                                    cell.Range.Text = machine.list_OpenPorts[i].serviceName;
                                cell.Range.Font.Name = "times new roman";
                                cell.Range.Font.Size = 14;
                                cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                cell.Range.ParagraphFormat.SpaceAfter = 1F;
                                
                            }
                        }
                    i++;
                    }
                Microsoft.Office.Interop.Word.Paragraph NewLine = document.Content.Paragraphs.Add(ref missing);
                NewLine.Range.Text = Environment.NewLine;
                NewLine.Range.InsertParagraphAfter();

            }

                //Save the document  
                object filename = filePath.Replace(Path.GetFileName(filePath), Path.GetFileName(filePath) + "_ToWord.docx");
                bool isExist = File.Exists(filename.ToString());
                int j = 1;
                while (isExist) 
                {
                        
                    if (isExist)
                        filename = filePath.Replace(Path.GetFileName(filePath), Path.GetFileName(filePath) + "_ToWord_"+ j +".docx");
                    j++;
                    isExist = File.Exists(filename.ToString());
                }    
                
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                textBox_Status.Text = "Document created successfully !";
                textBox_OutputFileName.Text = Path.GetFileName(filename.ToString());
            }
            catch (Exception ex)
            {
                textBox_Status.Text = ex.Message;
            }
        }
    }
}
