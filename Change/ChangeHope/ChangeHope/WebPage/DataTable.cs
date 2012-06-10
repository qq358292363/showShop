namespace ChangeHope.WebPage
{
    using ChangeHope.Common;
    using System;
    using System.Data.SqlClient;

    public class DataTable
    {
        private SqlDataReader dataReader = null;
        private string rowHead = "";
        private string rowText = "";
        private string toolbar = "";

        public string GetDataTable()
        {
            string str2;
            Table table = new Table();
            try
            {
                int @int = PageRequest.GetInt("pageindex");
                if (@int < 0)
                {
                    @int = 1;
                }
                table.AddHead(this.rowHead);
                string[] strArray = this.rowText.Split(new char[] { ',' });
                int num2 = 0;
                if (this.DataReader != null)
                {
                    while (this.DataReader.Read())
                    {
                        num2++;
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].IndexOf('$') >= 0)
                            {
                                string format = strArray[i].Split(new char[] { '$' })[0];
                                string[] strArray2 = strArray[i].Split(new char[] { '$' })[1].Split(new char[] { '|' });
                                string[] strArray3 = new string[strArray2.Length];
                                for (int j = 0; j < strArray2.Length; j++)
                                {
                                    if (strArray2[j].Equals("@num"))
                                    {
                                        strArray3[j] = num2.ToString();
                                    }
                                    else if (strArray2[j].Equals("@allnum"))
                                    {
                                        strArray3[j] = ((15 * (@int - 1)) + num2).ToString();
                                    }
                                    else if (strArray2[j].IndexOf("@sub") >= 0)
                                    {
                                        string[] strArray4 = strArray2[j].Split(new char[] { '#' });
                                        strArray3[j] = StringHelper.SubStringAndAppend(this.dataReader[strArray4[1]].ToString(), int.Parse(strArray4[2]), "");
                                    }
                                    else
                                    {
                                        strArray3[j] = this.dataReader[strArray2[j]].ToString();
                                    }
                                }
                                table.AddCol(format, strArray3);
                            }
                            else
                            {
                                table.AddCol(this.dataReader[strArray[i]].ToString());
                            }
                        }
                        table.AddRow();
                    }
                }
                str2 = table.GetTable();
            }
            catch (Exception exception)
            {
                str2 = exception.ToString();
            }
            finally
            {
                table = null;
            }
            return str2;
        }

        public SqlDataReader DataReader
        {
            get
            {
                return this.dataReader;
            }
            set
            {
                this.dataReader = value;
            }
        }

        public string RowHead
        {
            get
            {
                return this.rowHead;
            }
            set
            {
                this.rowHead = value;
            }
        }

        public string RowText
        {
            get
            {
                return this.rowText;
            }
            set
            {
                this.rowText = value;
            }
        }

        public string Toolbar
        {
            get
            {
                return this.toolbar;
            }
            set
            {
                this.toolbar = value;
            }
        }
    }
}

