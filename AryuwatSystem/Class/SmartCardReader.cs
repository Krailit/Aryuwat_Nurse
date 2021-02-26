using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDNIDWRAPPER;
using Entity;
using System.Drawing;
using System.IO;

namespace AryuwatSystem.Class
{
    public class SmartCardReader
    {
       public SmardCard_FIELD SmardCard = new SmardCard_FIELD();
        public string SmardDevice = "";
        string smsAlert = "";
            RDNIDWRAPPER.RDNID mRDNIDWRAPPER = new RDNIDWRAPPER.RDNID();
            string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            //public static string GetCurrentExecutingDirectory(System.Reflection.Assembly assembly)
            //{
            //    string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            //    return Path.GetDirectoryName(filePath);
            //}

            //public Form1()
            //{
            //    InitializeComponent();

            //    string fileName = StartupPath + "\\RDNIDLib.DLD";
            //    if (System.IO.File.Exists(fileName) == false)
            //    {
            //        MessageBox.Show("RDNIDLib.DLD not found");
            //    }

            //    System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //    this.Text = String.Format("R&D NID Card Plus C# {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            //    byte[] _lic = String2Byte(fileName);

            //    int nres = 0;
            //    nres = RDNID.openNIDLibRD(_lic);
            //    if (nres != 0)
            //    {
            //        String m;
            //        m = String.Format(" error no {0} ", nres);
            //        MessageBox.Show(m);
            //    }

            //    byte[] Licinfo = new byte[1024];

            //    RDNID.getLicenseInfoRD(Licinfo);

            //    m_lblDLDInfo.Text = aByteToString(Licinfo);

            //    byte[] Softinfo = new byte[1024];
            //    RDNID.getSoftwareInfoRD(Softinfo);
            //    m_lblSoftwareInfo.Text = aByteToString(Softinfo);

            //    ListCardReader();

            //}

            public IntPtr selectReader(String reader)
            {
                IntPtr mCard = (IntPtr)0;
                byte[] _reader = String2Byte(reader);
                IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
                if ((Int64)res > 0)
                    mCard = (IntPtr)res;
                return mCard;
            }

            private void ListCardReader()
            {
                byte[] szReaders = new byte[1024 * 2];
                int size = szReaders.Length;
                int numreader = RDNID.getReaderListRD(szReaders, size);
                if (numreader <= 0)
                    return;
                String s = aByteToString(szReaders);
                String[] readlist = s.Split(';');
                if (readlist != null)
                {
                    for (int i = 0; i < readlist.Length; i++)
                        SmardDevice = readlist[i];
                    //    m_ListReaderCard.Items.Add(readlist[i]);
                    //m_ListReaderCard.SelectedIndex = 0;

                    
                }
            }
            public string aByteToString(byte[] b)
            {
                Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
                int i;
                for (i = 0; b[i] != 0; i++) ;

                string s = ut.GetString(b);
                s = s.Substring(0, i);
                return s;
            }

            public byte[] String2Byte(string s)
            {
                // Create two different encodings.
                Encoding ascii = Encoding.GetEncoding(874);
                Encoding unicode = Encoding.Unicode;

                // Convert the string into a byte array.
                byte[] unicodeBytes = unicode.GetBytes(s);

                // Perform the conversion from one encoding to the other.
                byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

                return asciiBytes;
            }

            String _Thaiyyyymmdd_(String d)
            {
                string s = "";
                string _yyyy = d.Substring(0, 4);
                string _mm = d.Substring(4, 2);
                string _dd = d.Substring(6, 2);


                string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
                string _tm = "-";
                if (_mm == "00")
                {
                    _tm = "-";
                }
                else
                {
                    _tm = mm[int.Parse(_mm)];
                }
                if (_yyyy == "0000")
                    _yyyy = "-";

                if (_dd == "00")
                    _dd = "-";

                s = _dd + " " + _tm + " " + _yyyy;
                return s;
            }
            String _yyyymmdd_(String d)
            {
                string s = "";
                int y =Convert.ToInt16(d.Substring(0, 4));
                string y_E = y > 2500 ? (y - 543)+"" : y+"";
                string _yyyy = d.Substring(0, 4);
                string _mm = d.Substring(4, 2);
                string _dd = d.Substring(6, 2);


                string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
                string _tm = "-";
                if (_mm == "00")
                {
                    _tm = "-";
                }
                else
                {
                    _tm = mm[int.Parse(_mm)];
                }
                if (_yyyy == "0000")
                    _yyyy = "-";

                if (_dd == "00")
                    _dd = "-";

                s = y_E + "/" + _mm + "/" + _dd;
                return s;
            }


            enum NID_FIELD
            {
                NID_Number,   //1234567890123#

                TITLE_T,    //Thai title#
                NAME_T,     //Thai name#
                MIDNAME_T,  //Thai mid name#
                SURNAME_T,  //Thai surname#

                TITLE_E,    //Eng title#
                NAME_E,     //Eng name#
                MIDNAME_E,  //Eng mid name#
                SURNAME_E,  //Eng surname#

                HOME_NO,    //12/34#
                MOO,        //10#
                TROK,       //ตรอกxxx#
                SOI,        //ซอยxxx#
                ROAD,       //ถนนxxx#
                TUMBON,     //ตำบลxxx#
                AMPHOE,     //อำเภอxxx#
                PROVINCE,   //จังหวัดxxx#

                GENDER,     //1#			//1=male,2=female

                BIRTH_DATE, //25200131#	    //YYYYMMDD 
                ISSUE_PLACE,//xxxxxxx#      //
                ISSUE_DATE, //25580131#     //YYYYMMDD 
                EXPIRY_DATE,//25680130      //YYYYMMDD 
                ISSUE_NUM,  //12345678901234 //14-Char
                END
            };

            public SmardCard_FIELD ReadCardOrg()
            {
                //String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                SmardCard = new SmardCard_FIELD();
                IntPtr obj = selectReader(SmardDevice);


                Int32 nInsertCard = 0;
                nInsertCard = RDNID.connectCardRD(obj);
                if (nInsertCard != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nInsertCard);
                    //MessageBox.Show(m);

                    RDNID.disconnectCardRD(obj);
                    RDNID.deselectReaderRD(obj);
                    //return nInsertCard;
                }


                //BindDataToScreen();
                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
              //  if (res != DefineConstants.NID_SUCCESS)
                    //return res;
                String NIDNum = aByteToString(id);



                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                //if (res != DefineConstants.NID_SUCCESS)
                //    return res;

                String NIDData = aByteToString(data);
                if (NIDData == "")
                {
                    //MessageBox.Show("Read Text error");
                    smsAlert = "Read Text error";
                }
                else
                {
                    string[] fields = NIDData.Split('#');

                    SmardCard.NID_Number = NIDNum;                             // or use m_txtID.Text = fields[(int)NID_FIELD.NID_Number];

                    String fullname = fields[(int)NID_FIELD.TITLE_T] + " " +
                                        fields[(int)NID_FIELD.NAME_T] + " " +
                                        fields[(int)NID_FIELD.MIDNAME_T] + " " +
                                        fields[(int)NID_FIELD.SURNAME_T];
                    SmardCard.NAME_T = fullname;

                    fullname = fields[(int)NID_FIELD.TITLE_E] + " " +
                                        fields[(int)NID_FIELD.NAME_E] + " " +
                                        fields[(int)NID_FIELD.MIDNAME_E] + " " +
                                        fields[(int)NID_FIELD.SURNAME_E];
                    SmardCard.NAME_E = fullname;

                    SmardCard.BIRTH_DATE = _yyyymmdd_(fields[(int)NID_FIELD.BIRTH_DATE]);

                    SmardCard.HOME_NO = fields[(int)NID_FIELD.HOME_NO] + "";
                    SmardCard.MOO=fields[(int)NID_FIELD.MOO] + "";
                    SmardCard.TROK=fields[(int)NID_FIELD.TROK] + "";
                    SmardCard.SOI=fields[(int)NID_FIELD.SOI] + "";
                    SmardCard.ROAD=fields[(int)NID_FIELD.ROAD] + "";
                    SmardCard.TUMBON=fields[(int)NID_FIELD.TUMBON] + "";
                    SmardCard.AMPHOE=fields[(int)NID_FIELD.AMPHOE] + "";
                    SmardCard.PROVINCE=fields[(int)NID_FIELD.PROVINCE] + "";
                                            ;
                    

                    if (fields[(int)NID_FIELD.GENDER] == "1")
                    {
                        SmardCard.GENDER = "M";// "ชาย";
                    }
                    else
                    {
                        SmardCard.GENDER = "W";// "หญิง";
                    }
                    SmardCard.ISSUE_DATE= _yyyymmdd_(fields[(int)NID_FIELD.ISSUE_DATE]);
                    SmardCard.EXPIRY_DATE= _yyyymmdd_(fields[(int)NID_FIELD.EXPIRY_DATE]);
                    if ("99999999" == SmardCard.EXPIRY_DATE)
                        SmardCard.EXPIRY_DATE= "99999999 ตลอดชีพ";
                    SmardCard.ISSUE_NUM= fields[(int)NID_FIELD.ISSUE_NUM];
                }

                byte[] NIDPicture = new byte[1024 * 5];
                int imgsize = NIDPicture.Length;
                res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                //if (res != DefineConstants.NID_SUCCESS)
                //    return res;

                byte[] byteImage = NIDPicture;
                if (byteImage == null)
                {
                    //MessageBox.Show("Read Photo error");
                    smsAlert = "Read Photo error";
                }
                else
                {
                    //m_picPhoto
                    Image img = Image.FromStream(new MemoryStream(byteImage));
                    Bitmap MyImage = new Bitmap(img, 297 - 2, 355 - 2);
                    SmardCard.MyImage = (Image)MyImage;
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
                return SmardCard;
            }
            public SmardCard_FIELD ReadCard()
            {
                //String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                SmardCard = new SmardCard_FIELD();
                IntPtr obj = selectReader(SmardDevice);


                Int32 nInsertCard = 0;
                nInsertCard = RDNID.connectCardRD(obj);
                if (nInsertCard != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nInsertCard);
                    //MessageBox.Show(m);

                    RDNID.disconnectCardRD(obj);
                    RDNID.deselectReaderRD(obj);
                    //return nInsertCard;
                }


                //BindDataToScreen();
                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
                //  if (res != DefineConstants.NID_SUCCESS)
                //return res;
                String NIDNum = aByteToString(id);



                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                //if (res != DefineConstants.NID_SUCCESS)
                //    return res;

                String NIDData = aByteToString(data);
                if (NIDData == "")
                {
                    //MessageBox.Show("Read Text error");
                    smsAlert = "Read Text error";
                }
                else
                {
                    string[] fields = NIDData.Split('#');

                    SmardCard.NID_Number = NIDNum;                             // or use m_txtID.Text = fields[(int)NID_FIELD.NID_Number];

                    //String fullname = fields[(int)NID_FIELD.TITLE_T] + " " +
                    //                    fields[(int)NID_FIELD.NAME_T] + " " +
                    //                    fields[(int)NID_FIELD.MIDNAME_T] + " " +
                    //                    fields[(int)NID_FIELD.SURNAME_T];
                    SmardCard.TITLE_T = fields[(int)NID_FIELD.TITLE_T];
                    SmardCard.NAME_T = fields[(int)NID_FIELD.NAME_T] + "";
                    SmardCard.SURNAME_T = fields[(int)NID_FIELD.SURNAME_T];

                    //fullname = fields[(int)NID_FIELD.TITLE_E] + " " +
                    //                    fields[(int)NID_FIELD.NAME_E] + " " +
                    //                    fields[(int)NID_FIELD.MIDNAME_E] + " " +
                    //                    fields[(int)NID_FIELD.SURNAME_E];
                    SmardCard.TITLE_E = fields[(int)NID_FIELD.TITLE_E];
                    SmardCard.NAME_E = fields[(int)NID_FIELD.NAME_E] + "";
                    SmardCard.MIDNAME_E = fields[(int)NID_FIELD.MIDNAME_E] + "";
                    SmardCard.SURNAME_E = fields[(int)NID_FIELD.SURNAME_E]+"";

                    SmardCard.BIRTH_DATE = _yyyymmdd_(fields[(int)NID_FIELD.BIRTH_DATE]);

                    SmardCard.HOME_NO = fields[(int)NID_FIELD.HOME_NO] + "";
                    SmardCard.MOO = fields[(int)NID_FIELD.MOO] + "";
                    SmardCard.TROK = fields[(int)NID_FIELD.TROK] + "";
                    SmardCard.SOI = fields[(int)NID_FIELD.SOI] + "";
                    SmardCard.ROAD = fields[(int)NID_FIELD.ROAD] + "";
                    SmardCard.TUMBON = fields[(int)NID_FIELD.TUMBON].Replace("ตำบล","").Replace("แขวง","").Trim();
                    SmardCard.AMPHOE = fields[(int)NID_FIELD.AMPHOE].Replace("อำเภอ", "").Replace("เขต", "").Trim();
                    SmardCard.PROVINCE = fields[(int)NID_FIELD.PROVINCE].Replace("จังหวัด", "").Trim();
                    ;


                    if (fields[(int)NID_FIELD.GENDER] == "1")
                    {
                        SmardCard.GENDER = "M";// "ชาย";
                    }
                    else
                    {
                        SmardCard.GENDER = "W";// "หญิง";
                    }
                    SmardCard.ISSUE_DATE = _yyyymmdd_(fields[(int)NID_FIELD.ISSUE_DATE]);
                    SmardCard.EXPIRY_DATE = _yyyymmdd_(fields[(int)NID_FIELD.EXPIRY_DATE]);
                    if ("99999999" == SmardCard.EXPIRY_DATE)
                        SmardCard.EXPIRY_DATE = "99999999 ตลอดชีพ";
                    SmardCard.ISSUE_NUM = fields[(int)NID_FIELD.ISSUE_NUM];
                }

                byte[] NIDPicture = new byte[1024 * 5];
                int imgsize = NIDPicture.Length;
                res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                //if (res != DefineConstants.NID_SUCCESS)
                //    return res;

                byte[] byteImage = NIDPicture;
                if (byteImage == null)
                {
                    //MessageBox.Show("Read Photo error");
                    smsAlert = "Read Photo error";
                }
                else
                {
                    //m_picPhoto
                    Image img = Image.FromStream(new MemoryStream(byteImage));
                    //img.Save("c:\\xxxxxx.jpg");
                    Bitmap MyImage = new Bitmap(img, 297 - 2, 355 - 2);
                    SmardCard.MyImage = (Image)MyImage;
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
                return SmardCard;
            }

            private void OnReadCardClick(object sender, EventArgs e)
            {
                //m_txtID.Text = "";
                //m_txtFullNameT.Text = "";
                //m_txtFullNameE.Text = "";
                //m_txtAddress.Text = "";
                //m_txtBrithDate.Text = "";
                //m_txtGender.Text = "";
                //m_txtIssueDate.Text = "";
                //m_txtExpiryDate.Text = "";
                //m_txtIssueNum.Text = "";
                //m_picPhoto.Image = null;
                SmardCard = new SmardCard_FIELD();
                ReadCard();
            }

            //private void btnloadLIC_Click(object sender, EventArgs e)
            //{
            //    byte[] _lic = String2Byte(StartupPath + "\\RDNIDLib.DLD");
            //    int res = RDNID.updateLicenseFileRD(_lic);
            //    if (res != 0)
            //    {
            //        string s = string.Format("Error : {0}", res);
            //        MessageBox.Show(s);
            //    }
            //}

            //private void btngetReaderID_Click(object sender, EventArgs e)
            //{
            //    m_txtReaderID.ResetText();
            //    this.Refresh();
            //    String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);

            //    IntPtr obj = selectReader(strTerminal);

            //    byte[] Rid = new byte[16];
            //    int res = RDNID.getRidDD(obj, Rid);
            //    if (res > 0)
            //    {
            //        m_txtReaderID.Text = BitConverter.ToString(Rid);
            //    }
            //    else
            //    {
            //        m_txtReaderID.Text = String.Format("{0}", res);
            //        MessageBox.Show(String.Format("{0}", res));
            //    }

            //    //m_txtGetRidRY.Text = mRDNIDWRAPPER.getRidDD();

            //    RDNID.deselectReaderRD(obj);
            //}

            //private void button2_Click(object sender, EventArgs e)
            //{
            //    m_txtID.Text = "";
            //    m_txtFullNameT.Text = "";
            //    m_txtFullNameE.Text = "";
            //    m_txtAddress.Text = "";
            //    m_txtBrithDate.Text = "";
            //    m_txtGender.Text = "";
            //    m_txtIssueDate.Text = "";
            //    m_txtExpiryDate.Text = "";
            //    m_txtIssueNum.Text = "";
            //    m_txtReaderID.Text = "";
            //    m_picPhoto.Image = null;
            //}

            //private void m_ListReaderCard_Click(object sender, EventArgs e)
            //{
            //    m_ListReaderCard.ResetText();
            //    m_ListReaderCard.Items.Clear();
            //    ListCardReader();
            //}

        }
    }
