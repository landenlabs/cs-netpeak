using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

namespace nsNetPeak
{
    public partial class GraphProperties : Form
    {
        public GraphProperties()
        {
            InitializeComponent();
        }

        ZedGraphControl m_graphC;
        GraphPane       m_pane;
        LineItem[]      m_curves;
        PointPairList[] m_data;

        public DialogResult Show(ZedGraphControl graphC, GraphPane pane, LineItem[] curves, PointPairList[] data)
        {
            m_graphC = graphC;
            m_pane = pane;
            m_curves = curves;
            m_data = data;

            ListViewItem item;
            graphList.Items.Clear();

            item = graphList.Items.Add(graphList.Items.Count.ToString());
            item.Tag = graphC;
            item.SubItems.Add("Graph");

            item = graphList.Items.Add(graphList.Items.Count.ToString());
            item.Tag = pane;
            item.SubItems.Add("Pane");

            for (int lIdx = 0; lIdx < curves.Length; lIdx++)
            {
                LineItem lineItem = curves[lIdx];

                if (lineItem != null)
                {
                    item = graphList.Items.Add(graphList.Items.Count.ToString());
                    item.Tag = lineItem;
                    item.SubItems.Add("Curve").Tag = lIdx;
                    item.SubItems.Add(lineItem.Label.Text);
                    item.SubItems.Add(" ").BackColor = lineItem.Color;
                    item.SubItems.Add(lineItem.Symbol.ToString());
                }
            }

            for (int dIdx = 0; dIdx < data.Length; dIdx++)
            {
                PointPairList points = data[dIdx];
                if (points != null)
                {
                    item = graphList.Items.Add(graphList.Items.Count.ToString());
                    item.Tag = points;
                    item.SubItems.Add("Data").Tag = dIdx;
                    item.SubItems.Add(points.Count.ToString());
                }
            }

            Show();
            return DialogResult.OK;
        }

        int selIndex = -1;
        private void graphList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.propertyGrid.SelectedObject = e.Item.Tag;
            selIndex = e.Item.Index;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void propertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (e.NewSelection.GridItemType == GridItemType.Property)
            {
                // propertyGrid.SelectedObject = e.NewSelection.Value;
            }
        }

    }
}
