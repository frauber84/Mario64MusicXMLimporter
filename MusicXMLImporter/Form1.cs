using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics; 

namespace WindowsFormsApplication1
{
    public partial class MusicXMLImporter : Form
    {

        public float TrackDuration = 0;
        public float LastTimestamp = 0;
        public int StaffWithoutName = 0;
        public bool isChord;
        public int ChordCount;

        private static string CheckBoxState(CheckBox chbox)
        {
            if (chbox.Checked == true) return "1";
            else return "0";
        }

        private static void SetCheckBoxState(CheckBox check, string value)
        {
            if (value == "1") check.Checked = true;
            else check.Checked = false;
                
        }
        
        private void ClearParts()
        {
            PartCh1.Items.Clear();
            PartCh2.Items.Clear();
            PartCh3.Items.Clear();
            PartCh4.Items.Clear();
            PartCh5.Items.Clear();
            PartCh6.Items.Clear();
            PartCh7.Items.Clear();
            PartCh8.Items.Clear();
            PartCh9.Items.Clear();
            PartCh10.Items.Clear();
            PartCh11.Items.Clear();
            PartCh12.Items.Clear();
            PartCh13.Items.Clear();
            PartCh14.Items.Clear();
            PartCh15.Items.Clear();
            PartCh16.Items.Clear();
        }

        private void AddInstrument(String inst)
        {
                InstCh1.Items.Add(inst);
                InstCh2.Items.Add(inst);
                InstCh3.Items.Add(inst);
                InstCh4.Items.Add(inst);
                InstCh5.Items.Add(inst);
                InstCh6.Items.Add(inst);
                InstCh7.Items.Add(inst);
                InstCh8.Items.Add(inst);
                InstCh9.Items.Add(inst);
                InstCh10.Items.Add(inst);
                InstCh11.Items.Add(inst);
                InstCh12.Items.Add(inst);
                InstCh13.Items.Add(inst);
                InstCh14.Items.Add(inst);
                InstCh15.Items.Add(inst);
                InstCh16.Items.Add(inst);
        }

        private void AddBlankInstruments(int InstCount)
        {
            for (int i = 0; i < InstCount; i++ )
            {
                InstCh1.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh2.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh3.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh4.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh5.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh6.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh7.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh8.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh9.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh10.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh11.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh12.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh13.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh14.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh15.Items.Add("Sound" + i.ToString() + " - ?? ");
                InstCh16.Items.Add("Sound" + i.ToString() + " - ?? ");
            }
        }


        public MusicXMLImporter()
        {
            InitializeComponent();
        }

        public void EnableChannels()
        {
            Ch1.Enabled = true;
            PartCh1.Enabled = true;
            InstCh1.Enabled = true;
            VolCh1.Enabled = true;
            PanCh1.Enabled = true;
            TransCh1.Enabled = true;
            PartCh1.SelectedIndex = 0;

            Ch2.Enabled = true;
            PartCh2.Enabled = true;
            InstCh2.Enabled = true;
            VolCh2.Enabled = true;
            PanCh2.Enabled = true;
            TransCh2.Enabled = true;
            PartCh2.SelectedIndex = 0;

            Ch3.Enabled = true;
            PartCh3.Enabled = true;
            InstCh3.Enabled = true;
            VolCh3.Enabled = true;
            PanCh3.Enabled = true;
            TransCh3.Enabled = true;
            PartCh3.SelectedIndex = 0;

            Ch4.Enabled = true;
            PartCh4.Enabled = true;
            InstCh4.Enabled = true;
            VolCh4.Enabled = true;
            PanCh4.Enabled = true;
            TransCh4.Enabled = true;
            PartCh4.SelectedIndex = 0;

            Ch5.Enabled = true;
            PartCh5.Enabled = true;
            InstCh5.Enabled = true;
            VolCh5.Enabled = true;
            PanCh5.Enabled = true;
            TransCh5.Enabled = true;
            PartCh5.SelectedIndex = 0;

            Ch6.Enabled = true;
            PartCh6.Enabled = true;
            InstCh6.Enabled = true;
            VolCh6.Enabled = true;
            PanCh6.Enabled = true;
            TransCh6.Enabled = true;
            PartCh6.SelectedIndex = 0;

            Ch7.Enabled = true;
            PartCh7.Enabled = true;
            InstCh7.Enabled = true;
            VolCh7.Enabled = true;
            PanCh7.Enabled = true;
            TransCh7.Enabled = true;
            PartCh7.SelectedIndex = 0;

            Ch8.Enabled = true;
            PartCh8.Enabled = true;
            InstCh8.Enabled = true;
            VolCh8.Enabled = true;
            PanCh8.Enabled = true;
            TransCh8.Enabled = true;
            PartCh8.SelectedIndex = 0;

            Ch9.Enabled = true;
            PartCh9.Enabled = true;
            InstCh9.Enabled = true;
            VolCh9.Enabled = true;
            PanCh9.Enabled = true;
            TransCh9.Enabled = true;
            PartCh9.SelectedIndex = 0;

            Ch10.Enabled = true;
            PartCh10.Enabled = true;
            InstCh10.Enabled = true;
            VolCh10.Enabled = true;
            PanCh10.Enabled = true;
            TransCh10.Enabled = true;
            PartCh10.SelectedIndex = 0;

            Ch11.Enabled = true;
            PartCh11.Enabled = true;
            InstCh11.Enabled = true;
            VolCh11.Enabled = true;
            PanCh11.Enabled = true;
            TransCh11.Enabled = true;
            PartCh11.SelectedIndex = 0;

            Ch12.Enabled = true;
            PartCh12.Enabled = true;
            InstCh12.Enabled = true;
            VolCh12.Enabled = true;
            PanCh12.Enabled = true;
            TransCh12.Enabled = true;
            PartCh12.SelectedIndex = 0;

            Ch13.Enabled = true;
            PartCh13.Enabled = true;
            InstCh13.Enabled = true;
            VolCh13.Enabled = true;
            PanCh13.Enabled = true;
            TransCh13.Enabled = true;
            PartCh13.SelectedIndex = 0;

            Ch14.Enabled = true;
            PartCh14.Enabled = true;
            InstCh14.Enabled = true;
            VolCh14.Enabled = true;
            PanCh14.Enabled = true;
            TransCh14.Enabled = true;
            PartCh14.SelectedIndex = 0;

            Ch15.Enabled = true;
            PartCh15.Enabled = true;
            InstCh15.Enabled = true;
            VolCh15.Enabled = true;
            PanCh15.Enabled = true;
            TransCh15.Enabled = true;
            PartCh15.SelectedIndex = 0;

            Ch16.Enabled = true;
            PartCh16.Enabled = true;
            InstCh16.Enabled = true;
            VolCh16.Enabled = true;
            PanCh16.Enabled = true;
            TransCh16.Enabled = true;
            PartCh16.SelectedIndex = 0;

        }

        public void DisableChannels()
        {
            Ch1.Enabled = false;
            PartCh1.Enabled = false;
            InstCh1.Enabled = false;
            VolCh1.Enabled = false;
            PanCh1.Enabled = false;
            TransCh1.Enabled = false;
            PartCh1.Items.Clear();

            Ch2.Enabled = false;
            PartCh2.Enabled = false;
            InstCh2.Enabled = false;
            VolCh2.Enabled = false;
            PanCh2.Enabled = false;
            TransCh2.Enabled = false;
            PartCh2.Items.Clear();

            Ch3.Enabled = false;
            PartCh3.Enabled = false;
            InstCh3.Enabled = false;
            VolCh3.Enabled = false;
            PanCh3.Enabled = false;
            TransCh3.Enabled = false;
            PartCh3.Items.Clear();

            Ch4.Enabled = false;
            PartCh4.Enabled = false;
            InstCh4.Enabled = false;
            VolCh4.Enabled = false;
            PanCh4.Enabled = false;
            TransCh4.Enabled = false;
            PartCh4.Items.Clear();

            Ch5.Enabled = false;
            PartCh5.Enabled = false;
            InstCh5.Enabled = false;
            VolCh5.Enabled = false;
            PanCh5.Enabled = false;
            TransCh5.Enabled = false;
            PartCh5.Items.Clear();

            Ch6.Enabled = false;
            PartCh6.Enabled = false;
            InstCh6.Enabled = false;
            VolCh6.Enabled = false;
            PanCh6.Enabled = false;
            TransCh6.Enabled = false;
            PartCh6.Items.Clear();

            Ch7.Enabled = false;
            PartCh7.Enabled = false;
            InstCh7.Enabled = false;
            VolCh7.Enabled = false;
            PanCh7.Enabled = false;
            TransCh7.Enabled = false;
            PartCh7.Items.Clear();

            Ch8.Enabled = false;
            PartCh8.Enabled = false;
            InstCh8.Enabled = false;
            VolCh8.Enabled = false;
            PanCh8.Enabled = false;
            TransCh8.Enabled = false;
            PartCh8.Items.Clear();

            Ch9.Enabled = false;
            PartCh9.Enabled = false;
            InstCh9.Enabled = false;
            VolCh9.Enabled = false;
            PanCh9.Enabled = false;
            TransCh9.Enabled = false;
            PartCh9.Items.Clear();

            Ch10.Enabled = false;
            PartCh10.Enabled = false;
            InstCh10.Enabled = false;
            VolCh10.Enabled = false;
            PanCh10.Enabled = false;
            TransCh10.Enabled = false;
            PartCh10.Items.Clear();

            Ch11.Enabled = false;
            PartCh11.Enabled = false;
            InstCh11.Enabled = false;
            VolCh11.Enabled = false;
            PanCh11.Enabled = false;
            TransCh11.Enabled = false;
            PartCh11.Items.Clear();

            Ch12.Enabled = false;
            PartCh12.Enabled = false;
            InstCh12.Enabled = false;
            VolCh12.Enabled = false;
            PanCh12.Enabled = false;
            TransCh12.Enabled = false;
            PartCh12.Items.Clear();

            Ch13.Enabled = false;
            PartCh13.Enabled = false;
            InstCh13.Enabled = false;
            VolCh13.Enabled = false;
            PanCh13.Enabled = false;
            TransCh13.Enabled = false;
            PartCh13.Items.Clear();

            Ch14.Enabled = false;
            PartCh14.Enabled = false;
            InstCh14.Enabled = false;
            VolCh14.Enabled = false;
            PanCh14.Enabled = false;
            TransCh14.Enabled = false;
            PartCh14.Items.Clear();

            Ch15.Enabled = false;
            PartCh15.Enabled = false;
            InstCh15.Enabled = false;
            VolCh15.Enabled = false;
            PanCh15.Enabled = false;
            TransCh15.Enabled = false;
            PartCh15.Items.Clear();

            Ch16.Enabled = false;
            PartCh16.Enabled = false;
            InstCh16.Enabled = false;
            VolCh16.Enabled = false;
            PanCh16.Enabled = false;
            TransCh16.Enabled = false;
            PartCh16.Items.Clear();

        }

        public void AddPart(string part)
        {
            PartCh1.Items.Add(part);
            PartCh2.Items.Add(part);
            PartCh3.Items.Add(part);
            PartCh4.Items.Add(part);
            PartCh5.Items.Add(part);
            PartCh6.Items.Add(part);
            PartCh7.Items.Add(part);
            PartCh8.Items.Add(part);
            PartCh9.Items.Add(part);
            PartCh10.Items.Add(part);
            PartCh11.Items.Add(part);
            PartCh12.Items.Add(part);
            PartCh13.Items.Add(part);
            PartCh14.Items.Add(part);
            PartCh15.Items.Add(part);
            PartCh16.Items.Add(part);
        }

        private void LoadXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose MusicXML file";
            dlg.Filter = "(.xml)|*.xml";
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                XMLFile.Text = dlg.FileName;

            }

        }

        private void InstrumentCh1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MusicXMLImporter_Load(object sender, EventArgs e)
        {
            DisableChannels();
            XMLFile.Text = "No file loaded!";
            InstSet.SelectedIndex = 17;
            sequenceInserterToolStripMenuItem.Enabled = false;
             
        }

        private void InstCh1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VolCh1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {

        }

        private void XMLFile_TextChanged(object sender, EventArgs e)
        {

            if (XMLFile.Text != "No file loaded!")
            {
                ClearParts();
                StaffWithoutName = 0;

                StreamReader streamReader = new StreamReader(XMLFile.Text);
                string xmlfile = streamReader.ReadToEnd();
                streamReader.Close();

                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.XmlResolver = null;
                    doc.LoadXml(xmlfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                FileInfo Path = new FileInfo(Application.ExecutablePath);
                string PartPath = Path.DirectoryName + "\\parts.txt";
                StreamWriter DebugText = new StreamWriter(PartPath);

                XmlNodeList parts = doc.GetElementsByTagName("part");

                if (parts.Count == 0) MessageBox.Show("Not a valid MusicXML file (no parts found)");

                if (parts.Count != 0)
                {

                    foreach (XmlNode node in parts)
                    {

                        TrackDuration = 0;
                        LastTimestamp = 0;

                        DebugText.Write("Part ");
                        XmlElement part = (XmlElement)node;

                        if (part.HasAttribute("id"))
                        {
                            String ID = part.Attributes["id"].InnerText;
                            DebugText.Write(ID + "\n");

                            XmlNodeList scoreparts = doc.GetElementsByTagName("score-part");

                            foreach (XmlNode node3 in scoreparts)
                            {
                                XmlElement scorepart = (XmlElement)node3;

                                if (scorepart.HasAttribute("id"))
                                {
                                    String partname = scorepart.Attributes["id"].InnerText;

                                    if (partname == ID)
                                    {

                                        XmlNodeList partname2 = scorepart.GetElementsByTagName("part-name");

                                        if (partname2.Count != 0)
                                        {
                                            String PartName = partname2[0].InnerText;

                                            StaffWithoutName += 1;
                                            if (PartName == "") PartName = "Unnamed staff #" + StaffWithoutName.ToString();

                                            DebugText.Write("Partname " + PartName + "\n");
                                            AddPart(PartName);


                                        }
                                    }

                                }

                            }

                        }

                        XmlNodeList div = part.GetElementsByTagName("divisions");
                        float partdivision = Convert.ToSingle(div[0].InnerText);
                        float divnumber = 48 / partdivision;

                        // Proceed measure-wise

                        XmlNodeList measure = part.GetElementsByTagName("measure");

                        int MeasureLenght = 0;
                        int MeasureTime = 0;

                        foreach (XmlNode measurenode in measure)
                        {
                            XmlElement currentmeasure = (XmlElement)measurenode;
                            DebugText.Write("New Measure (" + String.Format("{0:x}", MeasureTime) + ")\n");

                            XmlNodeList time = currentmeasure.GetElementsByTagName("time");
                            if (time.Count != 0)
                            {
                                XmlNodeList beats = currentmeasure.GetElementsByTagName("beats");
                                XmlNodeList beat_type = currentmeasure.GetElementsByTagName("beat-type");

                                int BeatLenght = 0;
                                switch (beat_type[0].InnerText)
                                {
                                    case "8":
                                        BeatLenght = 0x18;
                                        break;

                                    case "4":
                                        BeatLenght = 0x30;
                                        break;

                                    case "2":
                                        BeatLenght = 0x60;
                                        break;
                                }

                                MeasureLenght = BeatLenght * Convert.ToInt32(beats[0].InnerText);
                            }

                            MeasureTime += MeasureLenght;

                            XmlNodeList note = currentmeasure.GetElementsByTagName("note");

                            foreach (XmlNode node2 in note)
                            {

                                XmlElement notes = (XmlElement)node2;
                                XmlNodeList duration = notes.GetElementsByTagName("duration");
                                XmlNodeList pitch = notes.GetElementsByTagName("pitch");
                                XmlNodeList staff = notes.GetElementsByTagName("staff");
                                XmlNodeList rest = notes.GetElementsByTagName("rest");
                                XmlNodeList chord = notes.GetElementsByTagName("chord");
                                XmlNodeList voice = notes.GetElementsByTagName("voice");
                                XmlNodeList tie = notes.GetElementsByTagName("tie");

                                if (voice.Count != 0)
                                {
                                    if (voice[0].InnerText != "1") goto SkipNote;
                                }

                                if (staff.Count != 0)
                                {
                                    if (staff[0].InnerText != "1") goto SkipNote;
                                }

                                if (chord.Count != 0)
                                {
                                    ChordCount++; // so that first element isn't 0
                                    isChord = true;
                                    DebugText.Write("chord " + ChordCount.ToString() + " ");
                                }
                                else
                                {
                                    isChord = false;
                                    ChordCount = 0;
                                }

                                if (pitch.Count != 0)
                                {
                                    if (pitch[0].ChildNodes.Count > 1)
                                    {
                                        XmlNodeList step = notes.GetElementsByTagName("step");
                                        XmlNodeList alter = notes.GetElementsByTagName("alter");
                                        XmlNodeList octave = notes.GetElementsByTagName("octave");

                                        if (isChord == false) DebugText.Write("note ");

                                        int notenumber = 0;
                                        switch (step[0].InnerText)
                                        {
                                            case "A":
                                                notenumber = 9;
                                                break;

                                            case "B":
                                                notenumber = 11;
                                                break;

                                            case "C":
                                                notenumber = 0;
                                                break;

                                            case "D":
                                                notenumber = 2;
                                                break;

                                            case "E":
                                                notenumber = 4;
                                                break;

                                            case "F":
                                                notenumber = 5;
                                                break;

                                            case "G":
                                                notenumber = 7;
                                                break;
                                        }

                                        int octavenumber = Convert.ToInt32(octave[0].InnerText);

                                        if (octavenumber == 0) notenumber = notenumber + 3;
                                        else notenumber = (notenumber + ((octavenumber - 1) * 12)) + 3;

                                        if (notenumber < 0) notenumber = 0;

                                        if (alter.Count != 0) notenumber += Convert.ToInt32(alter[0].InnerText);

                                        DebugText.Write(String.Format("{0:x2} ", (uint)System.Convert.ToUInt32(Convert.ToString(notenumber))));

                                        if (duration.Count != 0)
                                        {
                                            float divduration = Convert.ToSingle(duration[0].InnerText) * divnumber;

                                            if (isChord == false) TrackDuration += divduration;

                                            if (isChord == false) LastTimestamp = divduration;

                                            DebugText.Write(String.Format("{0:x2} ", (uint)System.Convert.ToUInt32(Convert.ToString(divduration))));
                                        }

                                        DebugText.Write("64 10"); // note, velocity, gate time, duration comes after

                                        int tieStatus = 0;

                                        if (tie.Count != 0)
                                        {
                                            foreach (XmlNode tienode in tie)
                                            {
                                                XmlElement tied = (XmlElement)tienode;
                                                if (tied.HasAttribute("type"))
                                                {
                                                    if (tied.Attributes["type"].InnerText == "stop")
                                                    {
                                                        tieStatus = 2;
                                                    }
                                                    if (tied.Attributes["type"].InnerText == "start")
                                                    {
                                                        tieStatus = 1;
                                                    }
                                                }
                                            }
                                        }
                                        DebugText.Write(" " + tieStatus.ToString() + " ");
                                        DebugText.Write(String.Format("{0:x}", (uint)System.Convert.ToUInt32(Convert.ToString(TrackDuration - LastTimestamp))));
                                        DebugText.Write("\n");
                                    }
                                }

                                if (rest.Count != 0)
                                {
                                    DebugText.Write("rest ");

                                    if (duration.Count != 0)
                                    {
                                        float divduration = Convert.ToSingle(duration[0].InnerText) * divnumber;

                                        TrackDuration += divduration;

                                        LastTimestamp = divduration;

                                        DebugText.Write(String.Format("{0:x2}", (uint)System.Convert.ToUInt32(Convert.ToString(divduration))));
                                        DebugText.Write(" " + String.Format("{0:x}\n", (uint)System.Convert.ToUInt32(Convert.ToString(TrackDuration - LastTimestamp))));
                                    }
                                }
                            SkipNote: ;
                            }

                        }
                        DebugText.Write(String.Format("TotalTimestamp {0:x2}\n", (uint)System.Convert.ToUInt32(Convert.ToString(TrackDuration))));

                    }
                    DebugText.Close();
                    EnableChannels();

                }


            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void InstSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstCh1.Items.Clear();
            InstCh2.Items.Clear();
            InstCh3.Items.Clear();
            InstCh4.Items.Clear();
            InstCh5.Items.Clear();
            InstCh6.Items.Clear();
            InstCh7.Items.Clear();
            InstCh8.Items.Clear();
            InstCh9.Items.Clear();
            InstCh10.Items.Clear();
            InstCh11.Items.Clear();
            InstCh12.Items.Clear();
            InstCh13.Items.Clear();
            InstCh14.Items.Clear();
            InstCh15.Items.Clear();
            InstCh16.Items.Clear();


            if (InstSet.SelectedIndex == 0)
            {
                AddBlankInstruments(6);
            }
            else if (InstSet.SelectedIndex == 1)
            {
                AddBlankInstruments(9);
            }
            else if (InstSet.SelectedIndex == 2)
            {
                AddBlankInstruments(3);
            }
            else if (InstSet.SelectedIndex == 3)
            {
                AddBlankInstruments(0x0a);
            }
            else if (InstSet.SelectedIndex == 4)
            {
                AddBlankInstruments(0x10);
            }
            else if (InstSet.SelectedIndex == 5)
            {
                AddBlankInstruments(0x10);
            }
            else if (InstSet.SelectedIndex == 6)
            {
                AddBlankInstruments(0x10);
            }
            else if (InstSet.SelectedIndex == 7)
            {
                AddBlankInstruments(0x0f);
            }
            else if (InstSet.SelectedIndex == 8)
            {
                AddBlankInstruments(0x1b);
            }
            else if (InstSet.SelectedIndex == 9)
            {
                AddBlankInstruments(7);
            }
            else if (InstSet.SelectedIndex == 10)
            {
                AddBlankInstruments(0x18);
            }
            else if (InstSet.SelectedIndex == 11)
            {
                AddInstrument("00 - Acoustic Guitar");
                AddInstrument("01 - Accordeon");
                AddInstrument("02 - Ac??");
                AddInstrument("03 - Ac??");
                AddInstrument("04 - Ac??");
                AddInstrument("05 - Ac??");
                AddInstrument("06 - Low Accordeon");
                AddInstrument("07 - 07?");
                AddInstrument("08 - ??");
                AddInstrument("09 - ??");
                AddInstrument("10 - Crash Cymbal");
                AddInstrument("11 - Cymbal 2(?)");
            }
            else if (InstSet.SelectedIndex == 12)
            {
                AddInstrument("00 - ");
                AddInstrument("01 - ");
                AddInstrument("02 - ");
                AddInstrument("03 - ");
                AddInstrument("04 - ");
                AddInstrument("05 - ");
                AddInstrument("06 - Low instrument?");
                AddInstrument("07 - Recorder");
                AddInstrument("08 - ");
                AddInstrument("09 - ");
                AddInstrument("10 - ");
                AddInstrument("11 - Clash Cymbal");
                AddInstrument("12 - Snare Drum");
                AddInstrument("13 - Triangle");
                AddInstrument("14 - Triangle");
                AddInstrument("15 - Sine wave-like sound");
            }
            else if (InstSet.SelectedIndex == 13)
            {
                AddInstrument("00 - Banjo");
                AddInstrument("01 - Test me!");
                AddInstrument("02 - Fiddle");
                AddInstrument("03 - Test me!");
                AddInstrument("04 - Whistle with vibrato");
                AddInstrument("05 - Test me!");
                AddInstrument("06 - Acoustic Bass");
                AddInstrument("07 - Acoustic Bass");
                AddInstrument("08 - Acoustic Bass");
                AddInstrument("09 - Acoustic Bass");
                AddInstrument("10 - Test me!");
                AddInstrument("11 - Test me!");
                AddInstrument("12 - Test me!");
            }
            else if (InstSet.SelectedIndex == 14)
            {
                AddInstrument("00 - Strings");
                AddInstrument("01 - ?");
                AddInstrument("02 - ?");
                AddInstrument("03 - Pizzicato String");
                AddInstrument("04 - Cello (or low woodwind?)");
                AddInstrument("05 - Eletric Piano");
                AddInstrument("06 - ?");
            }
            else if (InstSet.SelectedIndex == 15)
            {
                AddInstrument("00 - Percussion loop");
                AddInstrument("01 - Voice 'Uhs'");
                AddInstrument("02 - Sitar drone notes");
                AddInstrument("03 - Sitar");
            }
            else if (InstSet.SelectedIndex == 16)
            {
                AddInstrument("00 - Low drone-like haunted sound");
                AddInstrument("01 - ");
                AddInstrument("02 - Low Cowbell");
                AddInstrument("03 - ");
                AddInstrument("04 - High Cowbell");
                AddInstrument("05 - ");
                AddInstrument("06 - ");
            }
            else if (InstSet.SelectedIndex == 17)
            {
                AddInstrument("00 - Snare Drum");
                AddInstrument("01 - Fingered Bass");
                AddInstrument("02 - Fingered Bass");
                AddInstrument("03 - Organ");
                AddInstrument("04 - Steel Drum");
                AddInstrument("05 - Trumpet");
                AddInstrument("06 - Slap Bass");
                AddInstrument("07 - Synth");
                AddInstrument("08 - Clavinet");
                AddInstrument("09 - Clavinet");
                AddInstrument("10 - Drum Sample (hi-hat)");
                AddInstrument("11 - Drum Sample");
                AddInstrument("12 - Drum Sample");
                AddInstrument("13 - Drum Sample");
            }
            else if (InstSet.SelectedIndex == 18)
            {
                AddBlankInstruments(0x0c);
            }
            else if (InstSet.SelectedIndex == 19)
            {
                AddBlankInstruments(0x10);
            }
            else if (InstSet.SelectedIndex == 20)
            {
                AddBlankInstruments(5);
            }
            else if (InstSet.SelectedIndex == 21)
            {
                AddBlankInstruments(0x0a);
            }
            else if (InstSet.SelectedIndex == 22)
            {
                AddBlankInstruments(2);
            }
            else if (InstSet.SelectedIndex == 23)
            {
                AddBlankInstruments(0x0d);
            }
            else if (InstSet.SelectedIndex == 24)
            {
                AddBlankInstruments(0x0f);
            }
            else if (InstSet.SelectedIndex == 25)
            {
                AddBlankInstruments(0x0d);
            }
            else if (InstSet.SelectedIndex == 26)
            {
                AddBlankInstruments(0x0d);
            }
            else if (InstSet.SelectedIndex == 27)
            {
                AddBlankInstruments(0x0c);
            }
            else if (InstSet.SelectedIndex == 28)
            {
                AddBlankInstruments(7);
            }
            else if (InstSet.SelectedIndex == 29)
            {
                AddBlankInstruments(6);
            }
            else if (InstSet.SelectedIndex == 30)
            {
                AddBlankInstruments(4);
            }
            else if (InstSet.SelectedIndex == 31)
            {
                AddBlankInstruments(0x0d);
            }
            else if (InstSet.SelectedIndex == 32)
            {
                AddBlankInstruments(9);
            }
            else if (InstSet.SelectedIndex == 33)
            {
                AddBlankInstruments(4);
            }
            else if (InstSet.SelectedIndex == 34)
            {
                AddBlankInstruments(0x0c);
            }
            else if (InstSet.SelectedIndex == 35)
            {
                AddBlankInstruments(0x08);
            }
            else if (InstSet.SelectedIndex == 36)
            {
                AddBlankInstruments(0x0a);
            }
            else if (InstSet.SelectedIndex == 37)
            {
                AddBlankInstruments(0x10);
            }

            InstCh1.SelectedIndex = 0;
            InstCh2.SelectedIndex = 0;
            InstCh3.SelectedIndex = 0;
            InstCh4.SelectedIndex = 0;
            InstCh5.SelectedIndex = 0;
            InstCh6.SelectedIndex = 0;
            InstCh7.SelectedIndex = 0;
            InstCh8.SelectedIndex = 0;
            InstCh9.SelectedIndex = 0;
            InstCh10.SelectedIndex = 0;
            InstCh11.SelectedIndex = 0;
            InstCh12.SelectedIndex = 0;
            InstCh13.SelectedIndex = 0;
            InstCh14.SelectedIndex = 0;
            InstCh15.SelectedIndex = 0;
            InstCh16.SelectedIndex = 0;

        }

        private void producem64FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (XMLFile.Text == "No file loaded!")
            {
                MessageBox.Show("Load a valid MusicXML file first!", "Error!", 0, MessageBoxIcon.Error);
                return;
            }

            if (Ch1.Checked == false && Ch2.Checked == false && Ch3.Checked == false &&
                Ch4.Checked == false && Ch5.Checked == false && Ch6.Checked == false &&
                Ch7.Checked == false && Ch8.Checked == false && Ch9.Checked == false &&
                Ch10.Checked == false && Ch11.Checked == false && Ch12.Checked == false &&
                Ch13.Checked == false && Ch14.Checked == false && Ch15.Checked == false &&
                Ch16.Checked == false)
            {
                MessageBox.Show("No channels selected!", "Error!", 0, MessageBoxIcon.Error);
                return;
            }

            FileInfo Path = new FileInfo(Application.ExecutablePath);
            string SettingsPath = Path.DirectoryName + "\\settings.txt";
            StreamWriter ImportSettings = new StreamWriter(SettingsPath);

            ImportSettings.WriteLine("Tempo " + Tempo.Value.ToString());
            ImportSettings.Write("Loop ");
            if (Loop.Checked == true) ImportSettings.WriteLine("1");
            else ImportSettings.WriteLine("0");

            ImportSettings.WriteLine("GlobalVolume " + GlobalVolume.Value.ToString());
            ImportSettings.WriteLine("GlobalTrans " + GlobalTransposition.Value.ToString());
            ImportSettings.WriteLine("NInst " + InstSet.SelectedIndex.ToString());

            if (Ch1.Checked == true)
            {
                ImportSettings.Write("Ch 1 ");
                ImportSettings.Write(PartCh1.Text + "\nChSet 1 ");
                ImportSettings.Write(InstCh1.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh1.Value.ToString() + " ");
                ImportSettings.Write(PanCh1.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh1.Value.ToString());
            }
            if (Ch2.Checked == true)
            {
                ImportSettings.Write("Ch 2 ");
                ImportSettings.Write(PartCh2.Text + "\nChSet 2 ");
                ImportSettings.Write(InstCh2.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh2.Value.ToString() + " ");
                ImportSettings.Write(PanCh2.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh2.Value.ToString());
            }
            if (Ch3.Checked == true)
            {
                ImportSettings.Write("Ch 3 ");
                ImportSettings.Write(PartCh3.Text + "\nChSet 3 ");
                ImportSettings.Write(InstCh3.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh3.Value.ToString() + " ");
                ImportSettings.Write(PanCh3.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh3.Value.ToString());
            }
            if (Ch4.Checked == true)
            {
                ImportSettings.Write("Ch 4 ");
                ImportSettings.Write(PartCh4.Text + "\nChSet 4 ");
                ImportSettings.Write(InstCh4.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh4.Value.ToString() + " ");
                ImportSettings.Write(PanCh4.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh4.Value.ToString());
            }
            if (Ch5.Checked == true)
            {
                ImportSettings.Write("Ch 5 ");
                ImportSettings.Write(PartCh5.Text + "\nChSet 5 ");
                ImportSettings.Write(InstCh5.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh5.Value.ToString() + " ");
                ImportSettings.Write(PanCh5.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh5.Value.ToString());
            }
            if (Ch6.Checked == true)
            {
                ImportSettings.Write("Ch 6 ");
                ImportSettings.Write(PartCh6.Text + "\nChSet 6 ");
                ImportSettings.Write(InstCh6.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh6.Value.ToString() + " ");
                ImportSettings.Write(PanCh6.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh6.Value.ToString());
            }
            if (Ch7.Checked == true)
            {
                ImportSettings.Write("Ch 7 ");
                ImportSettings.Write(PartCh7.Text + "\nChSet 7 ");
                ImportSettings.Write(InstCh7.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh7.Value.ToString() + " ");
                ImportSettings.Write(PanCh7.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh7.Value.ToString());
            }
            if (Ch8.Checked == true)
            {
                ImportSettings.Write("Ch 8 ");
                ImportSettings.Write(PartCh8.Text + "\nChSet 8 ");
                ImportSettings.Write(InstCh8.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh8.Value.ToString() + " ");
                ImportSettings.Write(PanCh8.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh8.Value.ToString());
            }
            if (Ch9.Checked == true)
            {
                ImportSettings.Write("Ch 9 ");
                ImportSettings.Write(PartCh9.Text + "\nChSet 9 ");
                ImportSettings.Write(InstCh9.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh9.Value.ToString() + " ");
                ImportSettings.Write(PanCh9.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh9.Value.ToString());
            }
            if (Ch10.Checked == true)
            {
                ImportSettings.Write("Ch 10 ");
                ImportSettings.Write(PartCh10.Text + "\nChSet 10 ");
                ImportSettings.Write(InstCh10.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh10.Value.ToString() + " ");
                ImportSettings.Write(PanCh10.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh10.Value.ToString());
            }
            if (Ch11.Checked == true)
            {
                ImportSettings.Write("Ch 11 ");
                ImportSettings.Write(PartCh11.Text + "\nChSet 11 ");
                ImportSettings.Write(InstCh11.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh11.Value.ToString() + " ");
                ImportSettings.Write(PanCh11.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh11.Value.ToString());
            }
            if (Ch12.Checked == true)
            {
                ImportSettings.Write("Ch 12 ");
                ImportSettings.Write(PartCh12.Text + "\nChSet 12 ");
                ImportSettings.Write(InstCh12.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh12.Value.ToString() + " ");
                ImportSettings.Write(PanCh12.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh12.Value.ToString());
            }
            if (Ch13.Checked == true)
            {
                ImportSettings.Write("Ch 13 ");
                ImportSettings.Write(PartCh13.Text + "\nChSet 13 ");
                ImportSettings.Write(InstCh13.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh13.Value.ToString() + " ");
                ImportSettings.Write(PanCh13.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh13.Value.ToString());
            }
            if (Ch14.Checked == true)
            {
                ImportSettings.Write("Ch 14 ");
                ImportSettings.Write(PartCh14.Text + "\nChSet 14 ");
                ImportSettings.Write(InstCh14.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh14.Value.ToString() + " ");
                ImportSettings.Write(PanCh14.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh14.Value.ToString());
            }
            if (Ch15.Checked == true)
            {
                ImportSettings.Write("Ch 15 ");
                ImportSettings.Write(PartCh15.Text + "\nChSet 15 ");
                ImportSettings.Write(InstCh15.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh15.Value.ToString() + " ");
                ImportSettings.Write(PanCh15.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh15.Value.ToString());
            }
            if (Ch16.Checked == true)
            {
                ImportSettings.Write("Ch 16 ");
                ImportSettings.Write(PartCh16.Text + "\nChSet 16 ");
                ImportSettings.Write(InstCh16.SelectedIndex.ToString() + " ");
                ImportSettings.Write(VolCh16.Value.ToString() + " ");
                ImportSettings.Write(PanCh16.Value.ToString() + " ");
                ImportSettings.WriteLine(TransCh16.Value.ToString());
            }

            ImportSettings.Close();

            string Argv0 = Path.DirectoryName + "\\M64XML.exe";
            string Argv1 = Path.DirectoryName + "\\parts.txt";
            string Argv2 = Path.DirectoryName + "\\settings.txt";

            if (File.Exists(Argv0))
            {
                Process ProcessObj = new Process();

                ProcessObj.StartInfo.FileName = Argv0;
                ProcessObj.StartInfo.Arguments = "\"" + Argv1 + "\" \"" + Argv2 + "\"";
                ProcessObj.StartInfo.UseShellExecute = false;
                ProcessObj.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Argv0);
                ProcessObj.Start();
                ProcessObj.WaitForExit();

                if (ProcessObj.ExitCode == -1)
                {
                    MessageBox.Show("Error!");
                }
                else MessageBox.Show(".m64 file created as " + System.IO.Path.GetDirectoryName(Argv0) + "\\output.m64");
            }
            else MessageBox.Show("M64XML.EXE not found!");


        }

        private void loadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose settings file";
            dlg.Filter = "(.set setting files)|*.set";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(dlg.FileName);
                string setfile = streamReader.ReadToEnd();
                streamReader.Close();

                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.LoadXml(setfile);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }

                XmlNodeList mxmlfile = doc.GetElementsByTagName("mxmlfile");
                if (mxmlfile.Count != 0) XMLFile.Text = mxmlfile[0].InnerText;
                XmlNodeList tempo = doc.GetElementsByTagName("tempo");
                if (tempo.Count != 0) Tempo.Value = Convert.ToInt32(tempo[0].InnerText);
                XmlNodeList globalvolume = doc.GetElementsByTagName("globalvolume");
                if (globalvolume.Count != 0) GlobalVolume.Value = Convert.ToInt32(globalvolume[0].InnerText);
                XmlNodeList instset = doc.GetElementsByTagName("instset");
                if (instset.Count != 0) InstSet.SelectedIndex = Convert.ToInt32(instset[0].InnerText);
                XmlNodeList globaltransposition = doc.GetElementsByTagName("globaltransposition");
                if (globaltransposition.Count != 0) GlobalTransposition.Value = Convert.ToInt32(globaltransposition[0].InnerText);
                XmlNodeList loop = doc.GetElementsByTagName("loop");
                if (loop.Count != 0) SetCheckBoxState(Loop, loop[0].InnerText);
                XmlNodeList ch1 = doc.GetElementsByTagName("ch1");
                if (ch1.Count != 0) SetCheckBoxState(Ch1, ch1[0].InnerText);
                XmlNodeList ch2 = doc.GetElementsByTagName("ch2");
                if (ch2.Count != 0) SetCheckBoxState(Ch2, ch2[0].InnerText);
                XmlNodeList ch3 = doc.GetElementsByTagName("ch3");
                if (ch3.Count != 0) SetCheckBoxState(Ch3, ch3[0].InnerText);
                XmlNodeList ch4 = doc.GetElementsByTagName("ch4");
                if (ch4.Count != 0) SetCheckBoxState(Ch4, ch4[0].InnerText);
                XmlNodeList ch5 = doc.GetElementsByTagName("ch5");
                if (ch5.Count != 0) SetCheckBoxState(Ch5, ch5[0].InnerText);
                XmlNodeList ch6 = doc.GetElementsByTagName("ch6");
                if (ch6.Count != 0) SetCheckBoxState(Ch6, ch6[0].InnerText);
                XmlNodeList ch7 = doc.GetElementsByTagName("ch7");
                if (ch7.Count != 0) SetCheckBoxState(Ch7, ch7[0].InnerText);
                XmlNodeList ch8 = doc.GetElementsByTagName("ch8");
                if (ch8.Count != 0) SetCheckBoxState(Ch8, ch8[0].InnerText);
                XmlNodeList ch9 = doc.GetElementsByTagName("ch9");
                if (ch9.Count != 0) SetCheckBoxState(Ch9, ch9[0].InnerText);
                XmlNodeList ch10 = doc.GetElementsByTagName("ch10");
                if (ch10.Count != 0) SetCheckBoxState(Ch10, ch10[0].InnerText);
                XmlNodeList ch11 = doc.GetElementsByTagName("ch11");
                if (ch11.Count != 0) SetCheckBoxState(Ch11, ch11[0].InnerText);
                XmlNodeList ch12 = doc.GetElementsByTagName("ch12");
                if (ch12.Count != 0) SetCheckBoxState(Ch12, ch12[0].InnerText);
                XmlNodeList ch13 = doc.GetElementsByTagName("ch13");
                if (ch13.Count != 0) SetCheckBoxState(Ch13, ch13[0].InnerText);
                XmlNodeList ch14 = doc.GetElementsByTagName("ch14");
                if (ch14.Count != 0) SetCheckBoxState(Ch14, ch14[0].InnerText);
                XmlNodeList ch15 = doc.GetElementsByTagName("ch15");
                if (ch15.Count != 0) SetCheckBoxState(Ch15, ch15[0].InnerText);
                XmlNodeList ch16 = doc.GetElementsByTagName("ch16");
                if (ch16.Count != 0) SetCheckBoxState(Ch16, ch16[0].InnerText);

                XmlNodeList partch1 = doc.GetElementsByTagName("partch1");
                if (partch1.Count != 0) PartCh1.SelectedIndex = Convert.ToInt32(partch1[0].InnerText);
                XmlNodeList partch2 = doc.GetElementsByTagName("partch2");
                if (partch1.Count != 0) PartCh2.SelectedIndex = Convert.ToInt32(partch2[0].InnerText);
                XmlNodeList partch3 = doc.GetElementsByTagName("partch3");
                if (partch1.Count != 0) PartCh3.SelectedIndex = Convert.ToInt32(partch3[0].InnerText);
                XmlNodeList partch4 = doc.GetElementsByTagName("partch4");
                if (partch1.Count != 0) PartCh4.SelectedIndex = Convert.ToInt32(partch4[0].InnerText);
                XmlNodeList partch5 = doc.GetElementsByTagName("partch5");
                if (partch1.Count != 0) PartCh5.SelectedIndex = Convert.ToInt32(partch5[0].InnerText);
                XmlNodeList partch6 = doc.GetElementsByTagName("partch6");
                if (partch1.Count != 0) PartCh6.SelectedIndex = Convert.ToInt32(partch6[0].InnerText);
                XmlNodeList partch7 = doc.GetElementsByTagName("partch7");
                if (partch1.Count != 0) PartCh7.SelectedIndex = Convert.ToInt32(partch7[0].InnerText);
                XmlNodeList partch8 = doc.GetElementsByTagName("partch8");
                if (partch1.Count != 0) PartCh8.SelectedIndex = Convert.ToInt32(partch8[0].InnerText);
                XmlNodeList partch9 = doc.GetElementsByTagName("partch9");
                if (partch1.Count != 0) PartCh9.SelectedIndex = Convert.ToInt32(partch9[0].InnerText);
                XmlNodeList partch10 = doc.GetElementsByTagName("partch10");
                if (partch1.Count != 0) PartCh10.SelectedIndex = Convert.ToInt32(partch10[0].InnerText);
                XmlNodeList partch11 = doc.GetElementsByTagName("partch11");
                if (partch1.Count != 0) PartCh11.SelectedIndex = Convert.ToInt32(partch11[0].InnerText);
                XmlNodeList partch12 = doc.GetElementsByTagName("partch12");
                if (partch1.Count != 0) PartCh12.SelectedIndex = Convert.ToInt32(partch12[0].InnerText);
                XmlNodeList partch13 = doc.GetElementsByTagName("partch13");
                if (partch1.Count != 0) PartCh13.SelectedIndex = Convert.ToInt32(partch13[0].InnerText);
                XmlNodeList partch14 = doc.GetElementsByTagName("partch14");
                if (partch1.Count != 0) PartCh14.SelectedIndex = Convert.ToInt32(partch14[0].InnerText);
                XmlNodeList partch15 = doc.GetElementsByTagName("partch15");
                if (partch1.Count != 0) PartCh15.SelectedIndex = Convert.ToInt32(partch15[0].InnerText);
                XmlNodeList partch16 = doc.GetElementsByTagName("partch16");
                if (partch1.Count != 0) PartCh16.SelectedIndex = Convert.ToInt32(partch16[0].InnerText);

                XmlNodeList instch1 = doc.GetElementsByTagName("instch1");
                if (instch1.Count != 0) InstCh1.SelectedIndex = Convert.ToInt32(instch1[0].InnerText);
                XmlNodeList instch2 = doc.GetElementsByTagName("instch2");
                if (instch1.Count != 0) InstCh2.SelectedIndex = Convert.ToInt32(instch2[0].InnerText);
                XmlNodeList instch3 = doc.GetElementsByTagName("instch3");
                if (instch1.Count != 0) InstCh3.SelectedIndex = Convert.ToInt32(instch3[0].InnerText);
                XmlNodeList instch4 = doc.GetElementsByTagName("instch4");
                if (instch1.Count != 0) InstCh4.SelectedIndex = Convert.ToInt32(instch4[0].InnerText);
                XmlNodeList instch5 = doc.GetElementsByTagName("instch5");
                if (instch1.Count != 0) InstCh5.SelectedIndex = Convert.ToInt32(instch5[0].InnerText);
                XmlNodeList instch6 = doc.GetElementsByTagName("instch6");
                if (instch1.Count != 0) InstCh6.SelectedIndex = Convert.ToInt32(instch6[0].InnerText);
                XmlNodeList instch7 = doc.GetElementsByTagName("instch7");
                if (instch1.Count != 0) InstCh7.SelectedIndex = Convert.ToInt32(instch7[0].InnerText);
                XmlNodeList instch8 = doc.GetElementsByTagName("instch8");
                if (instch1.Count != 0) InstCh8.SelectedIndex = Convert.ToInt32(instch8[0].InnerText);
                XmlNodeList instch9 = doc.GetElementsByTagName("instch9");
                if (instch1.Count != 0) InstCh9.SelectedIndex = Convert.ToInt32(instch9[0].InnerText);
                XmlNodeList instch10 = doc.GetElementsByTagName("instch10");
                if (instch1.Count != 0) InstCh10.SelectedIndex = Convert.ToInt32(instch10[0].InnerText);
                XmlNodeList instch11 = doc.GetElementsByTagName("instch11");
                if (instch1.Count != 0) InstCh11.SelectedIndex = Convert.ToInt32(instch11[0].InnerText);
                XmlNodeList instch12 = doc.GetElementsByTagName("instch12");
                if (instch1.Count != 0) InstCh12.SelectedIndex = Convert.ToInt32(instch12[0].InnerText);
                XmlNodeList instch13 = doc.GetElementsByTagName("instch13");
                if (instch1.Count != 0) InstCh13.SelectedIndex = Convert.ToInt32(instch13[0].InnerText);
                XmlNodeList instch14 = doc.GetElementsByTagName("instch14");
                if (instch1.Count != 0) InstCh14.SelectedIndex = Convert.ToInt32(instch14[0].InnerText);
                XmlNodeList instch15 = doc.GetElementsByTagName("instch15");
                if (instch1.Count != 0) InstCh15.SelectedIndex = Convert.ToInt32(instch15[0].InnerText);
                XmlNodeList instch16 = doc.GetElementsByTagName("instch16");
                if (instch1.Count != 0) InstCh16.SelectedIndex = Convert.ToInt32(instch16[0].InnerText);

                XmlNodeList volCh1 = doc.GetElementsByTagName("volCh1");
                if (volCh1.Count != 0) VolCh1.Value = Convert.ToInt32(volCh1[0].InnerText);
                XmlNodeList volCh2 = doc.GetElementsByTagName("volCh2");
                if (volCh1.Count != 0) VolCh2.Value = Convert.ToInt32(volCh2[0].InnerText);
                XmlNodeList volCh3 = doc.GetElementsByTagName("volCh3");
                if (volCh1.Count != 0) VolCh3.Value = Convert.ToInt32(volCh3[0].InnerText);
                XmlNodeList volCh4 = doc.GetElementsByTagName("volCh4");
                if (volCh1.Count != 0) VolCh4.Value = Convert.ToInt32(volCh4[0].InnerText);
                XmlNodeList volCh5 = doc.GetElementsByTagName("volCh5");
                if (volCh1.Count != 0) VolCh5.Value = Convert.ToInt32(volCh5[0].InnerText);
                XmlNodeList volCh6 = doc.GetElementsByTagName("volCh6");
                if (volCh1.Count != 0) VolCh6.Value = Convert.ToInt32(volCh6[0].InnerText);
                XmlNodeList volCh7 = doc.GetElementsByTagName("volCh7");
                if (volCh1.Count != 0) VolCh7.Value = Convert.ToInt32(volCh7[0].InnerText);
                XmlNodeList volCh8 = doc.GetElementsByTagName("volCh8");
                if (volCh1.Count != 0) VolCh8.Value = Convert.ToInt32(volCh8[0].InnerText);
                XmlNodeList volCh9 = doc.GetElementsByTagName("volCh9");
                if (volCh1.Count != 0) VolCh9.Value = Convert.ToInt32(volCh9[0].InnerText);
                XmlNodeList volCh10 = doc.GetElementsByTagName("volCh10");
                if (volCh1.Count != 0) VolCh10.Value = Convert.ToInt32(volCh10[0].InnerText);
                XmlNodeList volCh11 = doc.GetElementsByTagName("volCh11");
                if (volCh1.Count != 0) VolCh11.Value = Convert.ToInt32(volCh11[0].InnerText);
                XmlNodeList volCh12 = doc.GetElementsByTagName("volCh12");
                if (volCh1.Count != 0) VolCh12.Value = Convert.ToInt32(volCh12[0].InnerText);
                XmlNodeList volCh13 = doc.GetElementsByTagName("volCh13");
                if (volCh1.Count != 0) VolCh13.Value = Convert.ToInt32(volCh13[0].InnerText);
                XmlNodeList volCh14 = doc.GetElementsByTagName("volCh14");
                if (volCh1.Count != 0) VolCh14.Value = Convert.ToInt32(volCh14[0].InnerText);
                XmlNodeList volCh15 = doc.GetElementsByTagName("volCh15");
                if (volCh1.Count != 0) VolCh15.Value = Convert.ToInt32(volCh15[0].InnerText);
                XmlNodeList volCh16 = doc.GetElementsByTagName("volCh16");
                if (volCh1.Count != 0) VolCh16.Value = Convert.ToInt32(volCh16[0].InnerText);

                XmlNodeList panCh1 = doc.GetElementsByTagName("panCh1");
                if (panCh1.Count != 0) PanCh1.Value = Convert.ToInt32(panCh1[0].InnerText);
                XmlNodeList panCh2 = doc.GetElementsByTagName("panCh2");
                if (panCh1.Count != 0) PanCh2.Value = Convert.ToInt32(panCh2[0].InnerText);
                XmlNodeList panCh3 = doc.GetElementsByTagName("panCh3");
                if (panCh1.Count != 0) PanCh3.Value = Convert.ToInt32(panCh3[0].InnerText);
                XmlNodeList panCh4 = doc.GetElementsByTagName("panCh4");
                if (panCh1.Count != 0) PanCh4.Value = Convert.ToInt32(panCh4[0].InnerText);
                XmlNodeList panCh5 = doc.GetElementsByTagName("panCh5");
                if (panCh1.Count != 0) PanCh5.Value = Convert.ToInt32(panCh5[0].InnerText);
                XmlNodeList panCh6 = doc.GetElementsByTagName("panCh6");
                if (panCh1.Count != 0) PanCh6.Value = Convert.ToInt32(panCh6[0].InnerText);
                XmlNodeList panCh7 = doc.GetElementsByTagName("panCh7");
                if (panCh1.Count != 0) PanCh7.Value = Convert.ToInt32(panCh7[0].InnerText);
                XmlNodeList panCh8 = doc.GetElementsByTagName("panCh8");
                if (panCh1.Count != 0) PanCh8.Value = Convert.ToInt32(panCh8[0].InnerText);
                XmlNodeList panCh9 = doc.GetElementsByTagName("panCh9");
                if (panCh1.Count != 0) PanCh9.Value = Convert.ToInt32(panCh9[0].InnerText);
                XmlNodeList panCh10 = doc.GetElementsByTagName("panCh10");
                if (panCh1.Count != 0) PanCh10.Value = Convert.ToInt32(panCh10[0].InnerText);
                XmlNodeList panCh11 = doc.GetElementsByTagName("panCh11");
                if (panCh1.Count != 0) PanCh11.Value = Convert.ToInt32(panCh11[0].InnerText);
                XmlNodeList panCh12 = doc.GetElementsByTagName("panCh12");
                if (panCh1.Count != 0) PanCh12.Value = Convert.ToInt32(panCh12[0].InnerText);
                XmlNodeList panCh13 = doc.GetElementsByTagName("panCh13");
                if (panCh1.Count != 0) PanCh13.Value = Convert.ToInt32(panCh13[0].InnerText);
                XmlNodeList panCh14 = doc.GetElementsByTagName("panCh14");
                if (panCh1.Count != 0) PanCh14.Value = Convert.ToInt32(panCh14[0].InnerText);
                XmlNodeList panCh15 = doc.GetElementsByTagName("panCh15");
                if (panCh1.Count != 0) PanCh15.Value = Convert.ToInt32(panCh15[0].InnerText);
                XmlNodeList panCh16 = doc.GetElementsByTagName("panCh16");
                if (panCh1.Count != 0) PanCh16.Value = Convert.ToInt32(panCh16[0].InnerText);

                XmlNodeList transCh1 = doc.GetElementsByTagName("transCh1");
                if (transCh1.Count != 0) TransCh1.Value = Convert.ToInt32(transCh1[0].InnerText);
                XmlNodeList transCh2 = doc.GetElementsByTagName("transCh2");
                if (transCh1.Count != 0) TransCh2.Value = Convert.ToInt32(transCh2[0].InnerText);
                XmlNodeList transCh3 = doc.GetElementsByTagName("transCh3");
                if (transCh1.Count != 0) TransCh3.Value = Convert.ToInt32(transCh3[0].InnerText);
                XmlNodeList transCh4 = doc.GetElementsByTagName("transCh4");
                if (transCh1.Count != 0) TransCh4.Value = Convert.ToInt32(transCh4[0].InnerText);
                XmlNodeList transCh5 = doc.GetElementsByTagName("transCh5");
                if (transCh1.Count != 0) TransCh5.Value = Convert.ToInt32(transCh5[0].InnerText);
                XmlNodeList transCh6 = doc.GetElementsByTagName("transCh6");
                if (transCh1.Count != 0) TransCh6.Value = Convert.ToInt32(transCh6[0].InnerText);
                XmlNodeList transCh7 = doc.GetElementsByTagName("transCh7");
                if (transCh1.Count != 0) TransCh7.Value = Convert.ToInt32(transCh7[0].InnerText);
                XmlNodeList transCh8 = doc.GetElementsByTagName("transCh8");
                if (transCh1.Count != 0) TransCh8.Value = Convert.ToInt32(transCh8[0].InnerText);
                XmlNodeList transCh9 = doc.GetElementsByTagName("transCh9");
                if (transCh1.Count != 0) TransCh9.Value = Convert.ToInt32(transCh9[0].InnerText);
                XmlNodeList transCh10 = doc.GetElementsByTagName("transCh10");
                if (transCh1.Count != 0) TransCh10.Value = Convert.ToInt32(transCh10[0].InnerText);
                XmlNodeList transCh11 = doc.GetElementsByTagName("transCh11");
                if (transCh1.Count != 0) TransCh11.Value = Convert.ToInt32(transCh11[0].InnerText);
                XmlNodeList transCh12 = doc.GetElementsByTagName("transCh12");
                if (transCh1.Count != 0) TransCh12.Value = Convert.ToInt32(transCh12[0].InnerText);
                XmlNodeList transCh13 = doc.GetElementsByTagName("transCh13");
                if (transCh1.Count != 0) TransCh13.Value = Convert.ToInt32(transCh13[0].InnerText);
                XmlNodeList transCh14 = doc.GetElementsByTagName("transCh14");
                if (transCh1.Count != 0) TransCh14.Value = Convert.ToInt32(transCh14[0].InnerText);
                XmlNodeList transCh15 = doc.GetElementsByTagName("transCh15");
                if (transCh1.Count != 0) TransCh15.Value = Convert.ToInt32(transCh15[0].InnerText);
                XmlNodeList transCh16 = doc.GetElementsByTagName("transCh16");
                if (transCh1.Count != 0) TransCh16.Value = Convert.ToInt32(transCh16[0].InnerText);

            }

        }

        private void settomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save settings";
            dlg.Filter = "(.set setting files)|*.set";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                XmlTextWriter textWriter = new XmlTextWriter(dlg.FileName, null);
                textWriter.WriteStartDocument();
                textWriter.WriteComment("Mario 64 Music XML Importer Jul Alpha 1 Settings File");

                textWriter.WriteStartElement("m64seq", "");

                textWriter.WriteStartElement("mxmlfile", "");
                textWriter.WriteString(XMLFile.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("tempo", "");
                textWriter.WriteString(Tempo.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("globalvolume", "");
                textWriter.WriteString(GlobalVolume.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("instset", "");
                textWriter.WriteString(InstSet.SelectedIndex.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("globaltransposition", "");
                textWriter.WriteString(GlobalTransposition.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("loop", "");
                textWriter.WriteString(CheckBoxState(Loop));
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("ch1", "");
                textWriter.WriteString(CheckBoxState(Ch1));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch2", "");
                textWriter.WriteString(CheckBoxState(Ch2));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch3", "");
                textWriter.WriteString(CheckBoxState(Ch3));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch4", "");
                textWriter.WriteString(CheckBoxState(Ch4));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch5", "");
                textWriter.WriteString(CheckBoxState(Ch5));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch6", "");
                textWriter.WriteString(CheckBoxState(Ch6));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch7", "");
                textWriter.WriteString(CheckBoxState(Ch7));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch8", "");
                textWriter.WriteString(CheckBoxState(Ch8));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch9", "");
                textWriter.WriteString(CheckBoxState(Ch9));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch10", "");
                textWriter.WriteString(CheckBoxState(Ch10));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch11", "");
                textWriter.WriteString(CheckBoxState(Ch11));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch12", "");
                textWriter.WriteString(CheckBoxState(Ch12));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch13", "");
                textWriter.WriteString(CheckBoxState(Ch13));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch14", "");
                textWriter.WriteString(CheckBoxState(Ch14));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch15", "");
                textWriter.WriteString(CheckBoxState(Ch15));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("ch16", "");
                textWriter.WriteString(CheckBoxState(Ch16));
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("partch1", "");
                textWriter.WriteString(PartCh1.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch2", "");
                textWriter.WriteString(PartCh2.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch3", "");
                textWriter.WriteString(PartCh3.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch4", "");
                textWriter.WriteString(PartCh4.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch5", "");
                textWriter.WriteString(PartCh5.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch6", "");
                textWriter.WriteString(PartCh6.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch7", "");
                textWriter.WriteString(PartCh7.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch8", "");
                textWriter.WriteString(PartCh8.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch9", "");
                textWriter.WriteString(PartCh9.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch10", "");
                textWriter.WriteString(PartCh10.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch11", "");
                textWriter.WriteString(PartCh11.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch12", "");
                textWriter.WriteString(PartCh12.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch13", "");
                textWriter.WriteString(PartCh13.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch14", "");
                textWriter.WriteString(PartCh14.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch15", "");
                textWriter.WriteString(PartCh15.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("partch16", "");
                textWriter.WriteString(PartCh16.SelectedIndex.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("instch1", "");
                textWriter.WriteString(InstCh1.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch2", "");
                textWriter.WriteString(InstCh2.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch3", "");
                textWriter.WriteString(InstCh3.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch4", "");
                textWriter.WriteString(InstCh4.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch5", "");
                textWriter.WriteString(InstCh5.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch6", "");
                textWriter.WriteString(InstCh6.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch7", "");
                textWriter.WriteString(InstCh7.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch8", "");
                textWriter.WriteString(InstCh8.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch9", "");
                textWriter.WriteString(InstCh9.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch10", "");
                textWriter.WriteString(InstCh10.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch11", "");
                textWriter.WriteString(InstCh11.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch12", "");
                textWriter.WriteString(InstCh12.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch13", "");
                textWriter.WriteString(InstCh13.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch14", "");
                textWriter.WriteString(InstCh14.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch15", "");
                textWriter.WriteString(InstCh15.SelectedIndex.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("instch16", "");
                textWriter.WriteString(InstCh16.SelectedIndex.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("volCh1", "");
                textWriter.WriteString(VolCh1.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh2", "");
                textWriter.WriteString(VolCh2.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh3", "");
                textWriter.WriteString(VolCh3.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh4", "");
                textWriter.WriteString(VolCh4.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh5", "");
                textWriter.WriteString(VolCh5.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh6", "");
                textWriter.WriteString(VolCh6.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh7", "");
                textWriter.WriteString(VolCh7.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh8", "");
                textWriter.WriteString(VolCh8.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh9", "");
                textWriter.WriteString(VolCh9.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh10", "");
                textWriter.WriteString(VolCh10.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh11", "");
                textWriter.WriteString(VolCh11.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh12", "");
                textWriter.WriteString(VolCh12.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh13", "");
                textWriter.WriteString(VolCh13.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh14", "");
                textWriter.WriteString(VolCh14.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh15", "");
                textWriter.WriteString(VolCh15.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("volCh16", "");
                textWriter.WriteString(VolCh16.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("panCh1", "");
                textWriter.WriteString(PanCh1.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh2", "");
                textWriter.WriteString(PanCh2.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh3", "");
                textWriter.WriteString(PanCh3.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh4", "");
                textWriter.WriteString(PanCh4.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh5", "");
                textWriter.WriteString(PanCh5.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh6", "");
                textWriter.WriteString(PanCh6.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh7", "");
                textWriter.WriteString(PanCh7.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh8", "");
                textWriter.WriteString(PanCh8.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh9", "");
                textWriter.WriteString(PanCh9.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh10", "");
                textWriter.WriteString(PanCh10.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh11", "");
                textWriter.WriteString(PanCh11.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh12", "");
                textWriter.WriteString(PanCh12.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh13", "");
                textWriter.WriteString(PanCh13.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh14", "");
                textWriter.WriteString(PanCh14.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh15", "");
                textWriter.WriteString(PanCh15.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("panCh16", "");
                textWriter.WriteString(PanCh16.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("transCh1", "");
                textWriter.WriteString(TransCh1.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh2", "");
                textWriter.WriteString(TransCh2.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh3", "");
                textWriter.WriteString(TransCh3.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh4", "");
                textWriter.WriteString(TransCh4.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh5", "");
                textWriter.WriteString(TransCh5.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh6", "");
                textWriter.WriteString(TransCh6.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh7", "");
                textWriter.WriteString(TransCh7.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh8", "");
                textWriter.WriteString(TransCh8.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh9", "");
                textWriter.WriteString(TransCh9.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh10", "");
                textWriter.WriteString(TransCh10.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh11", "");
                textWriter.WriteString(TransCh11.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh12", "");
                textWriter.WriteString(TransCh12.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh13", "");
                textWriter.WriteString(TransCh13.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh14", "");
                textWriter.WriteString(TransCh14.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh15", "");
                textWriter.WriteString(TransCh15.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("transCh16", "");
                textWriter.WriteString(TransCh16.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
                MessageBox.Show("Settings saved!");

            }

        }

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mario64 Music XML Importer by messiaen (aka frauber).\n\nJUL ALPHA VERSION 1");
        }

        private void sequenceInserterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

    }
        
}
