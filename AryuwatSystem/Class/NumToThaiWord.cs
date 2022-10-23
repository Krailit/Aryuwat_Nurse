using System;
using System.Collections.Generic;
using System.Text;


    public class MoneyExt
    {
        public static string NumberToThaiWord(double InputNumber)
        {
            string result;
            if (InputNumber == 0)
            {
                result = "";//"�ٹ��ҷ��ǹ";
                return result;
            }

            string NewInputNumber;
            NewInputNumber = InputNumber.ToString("####.00");
            if (Convert.ToDouble(NewInputNumber) >= 10000000000000)
            {
                result = "";
                return result;
            }

            string[] tmpNumber = new string[2];
            string FirstNumber;
            string LastNumber;

            tmpNumber = NewInputNumber.Split(Convert.ToChar("."));
            FirstNumber = tmpNumber[0];
            LastNumber = tmpNumber[1];

            int nLength = 0;
            nLength = Convert.ToInt32(FirstNumber.Length);

            int CNumber = 0;
            int CNumberBak = 0;
            string strNumber = "";
            string strPosition = "";
            string FinalWord = "";
            int CountPos = 0;

            for (int i = nLength; i >= 1; i--)
            {
                CNumberBak = CNumber;
                CNumber = Convert.ToInt32(FirstNumber.Substring(CountPos, 1));

                if (CNumber == 0 && i == 7)
                {
                    strPosition = "��ҹ";
                }
                else if (CNumber == 0)
                {
                    strPosition = "";
                }
                else
                {
                    strPosition = PositionToText(i);
                }

                if (CNumber == 2 && strPosition == "�Ժ")
                {
                    strNumber = "���";
                }
                else if (CNumber == 1 && strPosition == "�Ժ")
                {
                    strNumber = "";
                }
                else if (CNumber == 1 && strPosition == "��ҹ" && nLength >= 8)
                {
                    if (CNumberBak == 0)
                    {
                        strNumber = "˹��";
                    }
                    else
                    {
                        strNumber = "���";
                    }
                }
                else if (CNumber == 1 && strPosition == "" && nLength > 1)
                {
                    strNumber = "���";
                }
                else
                {
                    strNumber = NumberToText(CNumber);
                }

                CountPos = CountPos + 1;
                FinalWord = FinalWord + strNumber + strPosition;
            }

            CountPos = 0;
            CNumberBak = 0;
            nLength = Convert.ToInt32(LastNumber.Length);

            string Stang = "";
            string FinalStang = "";
            if (Convert.ToDouble(LastNumber) > 0)
            {
                for (int i = nLength; i >= 1; i--)
                {
                    CNumberBak = CNumber;
                    CNumber = Convert.ToInt32(LastNumber.Substring(CountPos, 1));
                    if (CNumber == 1 && i == 2)
                    {
                        strPosition = "�Ժ";
                    }
                    else if (CNumber == 0)
                    {
                        strPosition = "";
                    }
                    else
                    {
                        strPosition = PositionToText(i);
                    }

                    if (CNumber == 2 && strPosition == "�Ժ")
                    {
                        Stang = "���";
                    }
                    else if (CNumber == 1 && i == 2)
                    {
                        Stang = "";
                    }
                    else if (CNumber == 1 && strPosition == "" && nLength > 1)
                    {
                        if (CNumberBak == 0)
                        {
                            Stang = "˹��";
                        }
                        else
                        {
                            Stang = "���";
                        }
                    }
                    else
                    {
                        Stang = NumberToText(CNumber);
                    }

                    CountPos = CountPos + 1;
                    FinalStang = FinalStang + Stang + strPosition;
                }

                FinalStang = FinalStang + "ʵҧ��";
            }
            else
            {
                FinalStang = "";
            }

            string SubUnit;
            if (FinalStang == "")
            {
                SubUnit = "�ҷ��ǹ";
            }
            else
            {
                if (Convert.ToDouble(FirstNumber) != 0)
                {
                    SubUnit = "�ҷ";
                }
                else
                {
                    SubUnit = "";
                }
            }

            result = FinalWord + SubUnit + FinalStang;
            return result;
        }

        private static string NumberToText(int CurrentNum)
        {
            string _nText = "";

            switch (CurrentNum)
            {
                case 0: _nText = "";
                    break;
                case 1: _nText = "˹��";
                    break;
                case 2: _nText = "�ͧ";
                    break;
                case 3: _nText = "���";
                    break;
                case 4: _nText = "���";
                    break;
                case 5: _nText = "���";
                    break;
                case 6: _nText = "ˡ";
                    break;
                case 7: _nText = "��";
                    break;
                case 8: _nText = "Ỵ";
                    break;
                case 9: _nText = "���";
                    break;
            }

            return _nText;
        }

        private static string PositionToText(int CurrentPos)
        {
            string _nPos = "";

            switch (CurrentPos)
            {
                case 0: _nPos = "";
                    break;
                case 1: _nPos = "";
                    break;
                case 2: _nPos = "�Ժ";
                    break;
                case 3: _nPos = "����";
                    break;
                case 4: _nPos = "�ѹ";
                    break;
                case 5: _nPos = "����";
                    break;
                case 6: _nPos = "�ʹ";
                    break;
                case 7: _nPos = "��ҹ";
                    break;
                case 8: _nPos = "�Ժ";
                    break;
                case 9: _nPos = "����";
                    break;
                case 10: _nPos = "�ѹ";
                    break;
                case 11: _nPos = "����";
                    break;
                case 12: _nPos = "�ʹ";
                    break;
                case 13: _nPos = "��ҹ";
                    break;
            }

            return _nPos;
        }
    }

