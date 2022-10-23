using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing ;
using System.Windows.Forms;

namespace DatagridviewUsercontrol
{
    public partial class DatagridviewCheckboxHeader : DataGridView
    {
        public DatagridviewCheckboxHeader()
        {
            InitializeComponent();
            InitializeDatagridview();
        }

        public DatagridviewCheckboxHeader(IContainer container)
        {
            container.Add(this);
            //InitializeComponent();

            //���� CheckboxHeader Column tu_cs
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            CheckboxHeader = new DatagridViewCheckBoxHeaderCell();
            colCB.HeaderCell = CheckboxHeader;
            colCB.HeaderText = "";
            colCB.Resizable = DataGridViewTriState.False;
            colCB.Width = 40;
            this.Columns.Add(colCB);
            CheckboxHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            this.CellMouseUp += new DataGridViewCellMouseEventHandler(DatagridviewCheckboxHeader_CellMouseUp);
            this.CurrentCellDirtyStateChanged += new EventHandler(DatagridviewCheckboxHeader_CurrentCellDirtyStateChanged);
        }

        private void DatagridviewCheckboxHeader_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
       
        private void DatagridviewCheckboxHeader_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                CheckboxHeader.Checked = true;
                this.BeginEdit(true);
                foreach (DataGridViewRow row in this.Rows)
                {
                    if ((bool)row.Cells[0].Value == false)
                    {
                        CheckboxHeader.Checked = false;
                        this.Refresh();
                        return;
                    }
                }
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.Refresh();
            }
            catch
            { }
        }

        private void cbHeader_OnCheckBoxClicked(bool state)
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                this.EndEdit();
                if (row.ReadOnly == false) {
                    row.Cells[0].Value = state;
                }
                
                //row.Cells[0].Selected = true;
            }
        }             

        private void InitializeDatagridview()
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToResizeRows = false;
            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            this.RowHeadersVisible = false;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.Cursor = Cursors.Hand;
            this.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right)));          
        }         

    }
    /// <summary>
    /// class �������Ѻ ���ҧ �� CheckboxHeaderCell
    /// </summary>
    /// <param name="state"></param>
    #region CheckboxHeaderCell
    public delegate void CheckBoxClickedHandler(bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }

    public class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        //tu_cs
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }
        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }
    }
    #endregion     

    #region TextAndImage
    /// <summary>
    /// Class ���ҧ TextAndImageColumn
    /// </summary>
    public class TextAndImageColumn : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;

        public TextAndImageColumn()
        {
            this.CellTemplate = new TextAndImageCell();
        }

        public override object Clone()
        {
            TextAndImageColumn c = base.Clone() as TextAndImageColumn;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get { return this.imageValue; }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    if (this.InheritedStyle != null)
                    {
                        Padding inheritedPadding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(imageSize.Width,
                     inheritedPadding.Top, inheritedPadding.Right,
                     inheritedPadding.Bottom);
                    }
                }
            }
        }
        private TextAndImageCell TextAndImageCellTemplate
        {
            get { return this.CellTemplate as TextAndImageCell; }
        }
        internal Size ImageSize
        {
            get { return imageSize; }
        }
    }

    /// <summary>
    /// Class ���ҧ TextAndImageCell
    /// </summary>
    class TextAndImageCell : DataGridViewTextBoxCell
    {
        private Image imageValue;
        private Size imageSize;

        public override object Clone()
        {
            TextAndImageCell c = base.Clone() as TextAndImageCell;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get
            {
                if (this.OwningColumn == null ||
            this.OwningTextAndImageColumn == null)
                {

                    return imageValue;
                }
                else if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                else
                {
                    return this.OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    Padding inheritedPadding = this.InheritedStyle.Padding;
                    this.Style.Padding = new Padding(imageSize.Width,
                    inheritedPadding.Top, inheritedPadding.Right,
                    inheritedPadding.Bottom);
                }
            }
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
        Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        object value, object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
               value, formattedValue, errorText, cellStyle,
               advancedBorderStyle, paintParts);

            if (this.Image != null)
            {
                // Draw the image clipped to the cell.
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();

                graphics.SetClip(cellBounds);
                graphics.DrawImageUnscaled(this.Image, cellBounds.Location);

                graphics.EndContainer(container);
            }
        }

        private TextAndImageColumn OwningTextAndImageColumn
        {
            get { return this.OwningColumn as TextAndImageColumn; }
        }
    }
    #endregion 

}
