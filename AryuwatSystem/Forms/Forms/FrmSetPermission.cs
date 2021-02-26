using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DermasterSystem.Class;
using DermasterSystem.UserControls;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections;

namespace DermasterSystem.Forms
{
    public partial class FrmSetPermission : DockContent, IForm
    {
        public FrmSetPermission()
        {
            InitializeComponent();
        }
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            //DeleteData();
        }

        void IForm.IsRefresh()
        {
            //BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {
            //FrmPreviewRpt obj = new FrmPreviewRpt();
            //obj.FormName = "RptCustomerDetail";
            //obj.Cn = cn;
            //obj.StrBirthDate = txtYear.Text.Trim();
            //obj.MaximizeBox = true;
            //obj.ShowDialog();
        }

        void IForm.IsNew()
        {
            //NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Private Member
        private readonly Hashtable _htMenu = new Hashtable();
        private readonly Hashtable _htUserFunction = new Hashtable();
        private DataTable _dtFunction;
        private List<Entity.MenuPermission> _listGroupMapping;
        private Entity.MenuPermission gmInfo;
        private DataTable _dtGroupMapping;
        #endregion

        private void FrmSetPermission_Load(object sender, EventArgs e)
        {
            //SetColumns();
            tvFunction.AfterCheck += (TvFunctionAfterCheck); 
            cboUserGroup.SelectedIndexChanged += new EventHandler(cboUserGroup_SelectedIndexChanged);  
            BindDataGroupUser();
            RecurGenAllFunction();
        }

        void cboUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUserGroup.SelectedIndex ==0) return;
            SetHtUserFunction();
            RecurCheckNodeUser();
        }

        private void SetHtUserFunction()
        {
            _htUserFunction.Clear();
            _dtGroupMapping = new Business.MenuPermission().GetMenuPermissiongByGroupId(int.Parse(cboUserGroup.SelectedValue +"")).Tables[0];
            for (int i = 0; i < _dtGroupMapping.Rows.Count; i++)
            {
                var num2 = int.Parse(_dtGroupMapping.Rows[i]["GroupId"] + "");
                if (num2 == int.Parse( cboUserGroup.SelectedValue+""))
                {
                    string str = _dtGroupMapping.Rows[i]["MenuId"].ToString();
                    while (str != "0")
                    {
                        for (int j = 0; j < _dtFunction.Rows.Count; j++)
                        {
                            if (_dtFunction.Rows[j]["MenuId"].ToString() == str)
                            {
                                _htUserFunction[str] = str;
                                str = _dtFunction.Rows[j]["MenuParent"].ToString();
                                j = _dtFunction.Rows.Count;
                            }
                        }
                    }
                }
                else if (num2 > int.Parse(cboUserGroup.SelectedValue + ""))
                {
                    i = _dtGroupMapping.Rows.Count;
                }
            }
        }

        private void RecurCheckNodeUser()
        {
            for (int i = 0; i < tvFunction.Nodes.Count; i++)
            {
                RecurCheckNodeUser(tvFunction.Nodes[i]);
            }
        }


        private void RecurCheckNodeUser(TreeNode node)
        {
            node.Checked = _htUserFunction[_htMenu[node.Name]] != null;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node = node.Nodes[i];
                RecurCheckNodeUser(node);
                node = node.Parent;
            }
        }
        private void BindDataGroupUser()
        {
            try
            {
                DataTable dataTable = new Business.UserGroup().SelectUserGroupAll().Tables[0];
                DataRow dr = dataTable.NewRow();
                dr["ID"] = 0;
                dr["GroupName"] = "===โปรดระบุ===";
                dataTable.Rows.InsertAt(dr,0);
                cboUserGroup.DataSource = dataTable;
                cboUserGroup.DisplayMember = "GroupName";
                cboUserGroup.ValueMember = "ID";
                cboUserGroup.SelectedIndex = 0;
                //int? i = 1;
                //foreach (DataRowView row in dataTable.DefaultView)
                //{
                //    var myItems = new[]
                //                      {
                //                          i + "",
                //                          row["ID"]+"",
                //                          row["GroupName"]+""
                //                      };
                //    var lvi = new ListViewItem(myItems);
                //    lsvUserGroup.Items.Add(lvi);
                //    i += 1;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error : "+ ex.Message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        //private void SetColumns()
        //{
        //    Utility.SetUpListView(lsvUserGroup);
        //    lsvUserGroup.Columns.Add("No", 40);
        //    lsvUserGroup.Columns.Add("colId", "ID", 0);
        //    lsvUserGroup.Columns.Add("colGroupName", "ชื่อกลุ่ม", 250);
        //}

        private void TvFunctionAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                RecurCheckChild(e.Node, e.Node.Checked);
                if (e.Node.Checked)
                {
                    RecurCheckParrent(e.Node);
                }
            }
        }

        private void RecurCheckChild(TreeNode node, bool Checked)
        {
            node.Checked = Checked;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node = node.Nodes[i];
                RecurCheckChild(node, Checked);
                node = node.Parent;
            }
        }

        private void RecurCheckParrent(TreeNode node)
        {
            if (node.Parent != null)
            {
                node = node.Parent;
                node.Checked = true;
                RecurCheckParrent(node);
            }
        }

        private void RecurGenAllFunction()
        {
            _htMenu.Clear();
            tvFunction.Nodes.Clear();
            try
            {
                _dtFunction = new Business.Menu().SelectMenuAll().Tables[0];
                for (int i = 0; _dtFunction.Rows[i]["MenuParent"].ToString() == "0"; i++)
                {
                    var node = new TreeNode();
                    node.Text = _dtFunction.Rows[i]["MenuName"].ToString();
                    node.Name = _dtFunction.Rows[i]["MenuId"].ToString();
                    tvFunction.Nodes.Add(node);
                    _htMenu[node.Name] = _dtFunction.Rows[i]["MenuId"].ToString();
                    RecurGenAllFunction(_dtFunction, _dtFunction.Rows[i]["MenuId"].ToString(), node, i);
                }
                tvFunction.ExpandAll();
                tvFunction.SelectedNode = tvFunction.Nodes[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void RecurGenAllFunction(DataTable dt, string id, TreeNode myNode, int cur)
        {
            for (int i = cur; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MenuParent"].ToString() == id)
                {
                    myNode.Nodes.Add(dt.Rows[i]["MenuName"].ToString());
                    myNode = myNode.LastNode;
                    myNode.Name = dt.Rows[i]["MenuId"].ToString();
                    _htMenu[myNode.Name] = dt.Rows[i]["MenuId"].ToString();
                    RecurGenAllFunction(dt, dt.Rows[i]["MenuId"].ToString(), myNode, i);
                    myNode = myNode.Parent;
                }
            }
        }

        private void GetSelectedNode()
        {
            //this.sqlInsertSelect = "delete from _UserFunction where user_id=" + this.cur_user_id + " ; ";
            for (int i = 0; i < tvFunction.Nodes.Count; i++)
            {
                if (tvFunction.Nodes[i].Checked)
                {
                    GetSelectedNode(tvFunction.Nodes[i]);
                }
            }
        }

        private void GetSelectedNode(TreeNode myNode)
        {
            try
            {
                if (myNode.Checked)
                {
                    if (myNode.Nodes.Count > 0)
                    {
                        gmInfo = new Entity.MenuPermission
                        {
                            MenuId =_htMenu[myNode.Name]+"",
                            GroupId= int.Parse(cboUserGroup.SelectedValue +"")
                        };
                        _listGroupMapping.Add(gmInfo);


                        for (int i = 0; i < myNode.Nodes.Count; i++)
                        {
                            myNode = myNode.Nodes[i];
                            GetSelectedNode(myNode);
                            myNode = myNode.Parent;
                        }
                    }
                    else
                    {
                        gmInfo = new Entity.MenuPermission
                        {
                            MenuId =_htMenu[myNode.Name]+"",
                            GroupId = int.Parse(cboUserGroup.SelectedValue + "")
                        };
                        _listGroupMapping.Add(gmInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _listGroupMapping = null;
            gmInfo = new Entity.MenuPermission();
            _listGroupMapping = new List<Entity.MenuPermission>();
            try
            {
                GetSelectedNode();
                if (
                    MessageBox.Show(this, "คุณต้องการบันทึกข้อมูล ?", "ยืนยันการการบันทึกข้อมูลสิทธิ์การใช้งาน",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                    DialogResult.No)
                {
                    int? num = new Business.MenuPermission().InsertMenuPermission(_listGroupMapping.ToArray());
                    {
                        MessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว", "ผลการดำเนินการ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
          
        }

        private void FrmSetPermission_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmSetPermission = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmSetPermission = null;
            this.Close();
        }


    }
}
