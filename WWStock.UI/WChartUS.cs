using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.XPath;

namespace WWStock.UI
{
    public partial class WChartUS : UserControl
    {
        public struct Settings
        {
            public bool hasBorder;
            public bool hasPrice;
            public bool hasRate;
            public bool hasTitle;
            public bool hasVolume;
            public bool hasTime;
        }

        public struct ChartDefination
        {
            public int topBorderHeight;
            public int titleHeight;
            public int topSepHeight;
            public int upWaveHeight;
            public int waveMidLineHeight;
            public int downWaveHeight;
            public int volumeHeight;
            public int bottomSepHeight;
            public int timeHeight;
            public int bottomBorderHeight;
            public int leftBorderWidth;
            public int priceWidth;
            public int leftSepWidth;
            public int openWidth;
            public int waveWidth;
            public int rightSepWidth;
            public int rateWidth;
            public int rightBorderWidth;
        }

        public const int MINUTESPAN = 240;

        private ChartDefination cd;
        private Pen redDotPen;
        private Pen redSolidPen;
        private Pen whiteSolidPen;
        private Pen yellowSolidPen;
        private Pen greenSolidPen;

        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;

        private string code;
        private string name;
        private float last;
        private DateTime datetime;

        private List<WaveChartDataItem> list = new List<WaveChartDataItem>();
        private XPathNavigator nav;
        private int position;
        private int count;

        public void InitPens()
        {
            // create pens
            redDotPen = new Pen(Color.Red, 1);
            redDotPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            redSolidPen = new Pen(Color.Red, 1);
            redSolidPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            whiteSolidPen = new Pen(Color.White, 1);
            whiteSolidPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            yellowSolidPen = new Pen(Color.Yellow, 1);
            yellowSolidPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            greenSolidPen = new Pen(Color.Green, 1);
            greenSolidPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        public void InitChartDefination()
        {
            cd.topBorderHeight = 1;
            cd.titleHeight = 20;
            cd.topSepHeight = 1;
            cd.upWaveHeight = 120/*60*/;
            cd.waveMidLineHeight = 1;
            cd.downWaveHeight = 120/*60*/;
            cd.volumeHeight = 120/*60*/;
            cd.bottomSepHeight = 1;
            cd.timeHeight = 20;
            cd.bottomBorderHeight = 1;
            cd.leftBorderWidth = 1;
            cd.priceWidth = 46;
            cd.leftSepWidth = 1;
            cd.openWidth = 1;
            cd.waveWidth = 480/*240*/;
            cd.rightSepWidth = 1;
            cd.rateWidth = 34;
            cd.rightBorderWidth = 1;
        }

        public WChartUS()
        {
            InitializeComponent();

            InitChartDefination();
            InitPens();
            InitDoubleBuffer();
        }

        private void InitDoubleBuffer()
        {
            // Retrieves the BufferedGraphicsContext for the current application domain.
            context = BufferedGraphicsManager.Current;

            // Sets the maximum size for the primary graphics buffer of the buffered graphics context for the application domain.
            // Any allocation requests for a buffer larger than this will create a temporary buffered graphics context to host the graphics buffer.
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

            // Allocates a graphics buffer the size of this form using the pixel format of the Graphics created by 
            // the Form.CreateGraphics() method, which returns a Graphics object that matches the pixel format of the form.
            grafx = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
        }

        private bool GetWaveChartData()
        {
            try
            {
                XPathNodeIterator stockIter = nav.Select("/stock/stockItem[1]");
                stockIter.MoveNext();
                GetStockData(stockIter);

                this.count = stockIter.Current.Select("data/dayData").Count;
                this.position = this.count;
                XPathNodeIterator dayIter = stockIter.Current.Select("data/dayData[last()]");
                dayIter.MoveNext();
                GetDayData(dayIter);

                GetMinuteData(dayIter);
            }
            catch (Exception e)
            {
            	Debug.WriteLine("WWStock_User_Error: " + e.Message);
                return false;
            }

            return true;
        }

        private void MoveToDay(int pos)
        {
            try
            {
                string strXPath = string.Format("/stock/stockItem[@code=\'{0}\']/data/dayData[position()={1}]", code, pos);
                XPathNodeIterator dayIter = nav.Select(strXPath);
                dayIter.MoveNext();
                GetDayData(dayIter);

                GetMinuteData(dayIter);

                UpdateChart(list);
            }
            catch (System.Exception e)
            {
            	Debug.WriteLine(e.Message);
            }
        }

        private void GetStockData(XPathNodeIterator stockIter)
        {
            this.code = stockIter.Current.GetAttribute("code", "");
            this.name = stockIter.Current.GetAttribute("name", "");
        }

        private void GetDayData(XPathNodeIterator dayIter)
        {
            this.datetime = DateTime.Parse(dayIter.Current.GetAttribute("date", ""));
            this.last = float.Parse(dayIter.Current.GetAttribute("last", ""));
        }

        private void GetMinuteData(XPathNodeIterator dayIter)
        {
            list = new List<WaveChartDataItem>(240);
            int i = 0;
            WaveChartDataItem item = new WaveChartDataItem();
            XPathNodeIterator minIter = dayIter.Current.Select("minuteData");
            while (minIter.MoveNext())
            {
                PopulateWaveChartDataItem(minIter.Current, ++i, ref item);
                list.Add(item);
            }
        }

        private void PopulateWaveChartDataItem(XPathNavigator nav, int index, ref WaveChartDataItem item)
        {
            item.index = index;

            XPathNodeIterator openIter = nav.SelectChildren("open", "");
            openIter.MoveNext();
            item.open = (float)openIter.Current.ValueAsDouble;

            XPathNodeIterator lowIter = nav.SelectChildren("low", "");
            lowIter.MoveNext();
            item.low = (float)lowIter.Current.ValueAsDouble;

            XPathNodeIterator highIter = nav.SelectChildren("high", "");
            highIter.MoveNext();
            item.high = (float)highIter.Current.ValueAsDouble;

            XPathNodeIterator closeIter = nav.SelectChildren("close", "");
            closeIter.MoveNext();
            item.close = (float)closeIter.Current.ValueAsDouble;

            XPathNodeIterator volumeIter = nav.SelectChildren("volume", "");
            volumeIter.MoveNext();
            item.volume = volumeIter.Current.ValueAsDouble;
        }

        public void ChartSetup(XPathNavigator pathNav)
        {
            if (pathNav == null) return;

            try
            {
                this.nav = pathNav;

                GetWaveChartData();

                UpdateChart(list);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
                
        }

        public void ChartSetup(string code, string name, float last, DateTime dt, List<WaveChartDataItem> list)
        {
            this.code = code;
            this.name = name;
            this.last = last;
            this.datetime = dt;
            this.list = list;

            DrawChartBase(grafx.Graphics, last, 10.0f, 10/*5*/, 8);

            Invalidate();
        }

        private void UpdateChart(List<WaveChartDataItem> list)
        {
            UpdateBuffer(grafx.Graphics, list);

            Invalidate();
        }

        private void UpdateBuffer(Graphics dc, List<WaveChartDataItem> list)
        {
            if (list == null) return;
            if (list.Count == 0) return;

            double maxVolume = 0;
            float maxChange = 0;
            foreach (WaveChartDataItem item in list)
            {
                if (item.volume > maxVolume)
                {
                    maxVolume = item.volume;
                }

                if (Math.Abs(item.high - last) > maxChange)
                {
                    maxChange = Math.Abs(item.high - last);
                }
                if (Math.Abs(item.low - last) > maxChange)
                {
                    maxChange = Math.Abs(item.low - last);
                }
            }

            float xRate = cd.waveWidth / (float)MINUTESPAN;
            //float yRate = ((float)cd.upWaveHeight) * 10.0f / last;
            float yRate = cd.upWaveHeight / maxChange;
            float yVRate = (float)(maxVolume / cd.volumeHeight);

            DrawChartBase(dc, last, maxChange*100.0f/last, 10, 8);

            int xBase = cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth;
            int yBase = cd.topBorderHeight + cd.timeHeight + cd.topSepHeight + cd.upWaveHeight;
            int yVBase = cd.topBorderHeight + cd.timeHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight +
                         cd.downWaveHeight + cd.volumeHeight - 1;

            int xLast = 0;
            int yLast = 0;
            float close = 0;
            foreach (WaveChartDataItem item in list)
            {
                int x = (int)(item.index * xRate) + xBase - 1;
                int yOpen = yBase - (int)((item.open - last)*yRate);
                int yLow = yBase - (int)((item.low - last) * yRate);
                int yHigh = yBase - (int)((item.high - last) * yRate);
                int yClose = yBase - (int)((item.close - last) * yRate);
                int yVolume = yVBase - (int)(item.volume/yVRate);
                
                dc.DrawLine(whiteSolidPen, x, yLow, x, yHigh);
                //dc.DrawLine(item.close > ((item.index > 1) ? close : last) ? yellowSolidPen : greenSolidPen, x, yVBase, x, yVolume);
                dc.DrawLine(yellowSolidPen, x, yVBase, x, yVolume);
                if (item.index > 1)
                {
                    dc.DrawLine(whiteSolidPen, xLast, yLast, x, yOpen);
                }

                xLast = x;
                yLast = yClose;
                close = item.close;
            }

            string title = datetime.ToString("yyyy-MM-dd(ddd)") + "  " + code + "  " + name + "  "
                           + String.Format("{0:f}", close) + "  "
                           + String.Format("{0:f}%", (close - last)*100/last);
            DrawTitle(dc, title);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            grafx.Render(e.Graphics);
        }

        private void DrawChartBase(Graphics dc, float price, float percentage, int hDivision, int vDivision)
        {
            if (percentage < 0) percentage = 0;
            if (percentage > 100) percentage = 100;

            if (hDivision < 1) hDivision = 1;
            if (hDivision > 10) hDivision = 10;

            if (vDivision < 1) vDivision = 1;
            if (vDivision > 10) vDivision = 10;

            dc.Clear(Color.Black);
            //DrawTitle(dc);
            DrawWavePart(dc, hDivision, vDivision);
            DrawVolumePart(dc, 5, vDivision);
            DrawPrice(dc, price, percentage, hDivision);
            DrawRate(dc, percentage, hDivision);
        }

        private void DrawWavePart(Graphics dc, int hDivision, int vDivision)
        {
            // draw chart border
            dc.DrawRectangle(redSolidPen, 0,
                                        0,
                                        cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth + cd.rightSepWidth + cd.rateWidth + cd.rightBorderWidth - 1,
                                        cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight + cd.volumeHeight + cd.bottomSepHeight + cd.timeHeight + cd.bottomBorderHeight - 1);

            // draw wave frame
            dc.DrawRectangle(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                        cd.topBorderHeight + cd.titleHeight + cd.topSepHeight,
                                        cd.openWidth + cd.waveWidth - 1,
                                        cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight - 1);

            // draw wave mid line
            dc.DrawLine(redSolidPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                        cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight,
                                        cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth - 1,
                                        cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight);

            // draw wave vertical grid
            for (int i = 0; i < vDivision-1; i++)
            {
                dc.DrawLine(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth * (i + 1) / vDivision - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight,
                                            cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth * (i + 1) / vDivision - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight - 1);
            }

            // draw wave horizontal grid
            for (int i = 0; i < hDivision-1; i++ )
            {
                dc.DrawLine(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight * (i + 1) / hDivision,
                                            cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight * (i + 1) / hDivision);
            }

            for (int i = 0; i < hDivision-1; i++)
            {
                dc.DrawLine(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight * (i + 1) / hDivision,
                                            cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight * (i + 1) / hDivision);
            }
        }

        private void DrawVolumePart(Graphics dc, int hDivision, int vDivision)
        {
            // draw volume frame
            dc.DrawRectangle(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                        cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight,
                                        cd.openWidth + cd.waveWidth - 1,
                                        cd.volumeHeight - 1);

            // draw volume vertical grid
            for (int i = 0; i < vDivision - 1; i++)
            {
                dc.DrawLine(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth * (i + 1) / vDivision - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight,
                                            cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth * (i + 1) / vDivision - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight + cd.volumeHeight - 1);
            }

            // draw volume horizontal grid
            for (int i = 0; i < hDivision - 1; i++)
            {
                dc.DrawLine(redDotPen, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight + cd.volumeHeight * (i + 1) / hDivision,
                                            cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth - 1,
                                            cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight + cd.volumeHeight * (i + 1) / hDivision);
            }
        }

        private void DrawTitle(Graphics dc)
        {
            DrawTitle(dc, code + "    " + name);
        }

        private void DrawTitle(Graphics dc, string title)
        {
            Font font = new Font("Î¢ÈíÑÅºÚ", 10, FontStyle.Regular);     // font.Height = 18
            dc.DrawString(title, font, Brushes.White, cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth, cd.topBorderHeight);
        }

        private void DrawPriceItem(Graphics dc, Font font, Brush brush, float price, int x, int y)
        {
            string strPrice = String.Format("{0:f}", price);
            int offset = cd.priceWidth - (int)dc.MeasureString(strPrice, font).Width;
            dc.DrawString(strPrice, font, brush, x + offset, y - font.Height / 2);
        }

        private void DrawPrice(Graphics dc, float price, float percentage, int division)
        {
            Font font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);     // font.Height = 13
            int x = cd.leftBorderWidth;
            int y = cd.topBorderHeight + cd.titleHeight + cd.topSepHeight;

            for (int i = 0; i < division; i++)
            {
                DrawPriceItem(dc, font, Brushes.Tomato, (1.0f + percentage * (division - i) / division / 100.0f) * price, x, y + cd.upWaveHeight * i / division);
            }

            DrawPriceItem(dc, font, Brushes.White, price, x, y + cd.upWaveHeight);

            y += cd.upWaveHeight + cd.waveMidLineHeight;
            for (int i = 0; i < division; i++)
            {
                DrawPriceItem(dc, font, Brushes.Turquoise, (1.0f - percentage * (i + 1) / division / 100.0f) * price, x, y + cd.downWaveHeight * (i + 1) / division);
            }
        }

        private void DrawRate(Graphics dc, float percentage, int division)
        {
            Font font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);    // font.Height = 13

            for (int i = 0; i < division; i++)
            {
                dc.DrawString(String.Format("{0:0.0}%", (division - i) * percentage / division), font, Brushes.Tomato,
                    cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth + cd.rightSepWidth,
                    cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight * i / division - font.Height / 2);
            }

            dc.DrawString("0.0%", font, Brushes.White,
                cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth + cd.rightSepWidth,
                cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight - font.Height / 2);

            for (int i = 0; i < division; i++)
            {
                dc.DrawString(String.Format("{0:0.0}%", (i + 1) * percentage / division), font, Brushes.Turquoise,
                    cd.leftBorderWidth + cd.priceWidth + cd.leftSepWidth + cd.openWidth + cd.waveWidth + cd.rightSepWidth,
                    cd.topBorderHeight + cd.titleHeight + cd.topSepHeight + cd.upWaveHeight + cd.waveMidLineHeight + cd.downWaveHeight * (i + 1) / division - font.Height / 2);
            }
        }

        private void WChartUS_DoubleClick(object sender, EventArgs e)
        {
            UpdateChart(list);
        }

        private void WChartUS_Click(object sender, EventArgs e)
        {
            
        }

        private void WChartUS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // move to previous day
            }
            else if (e.Button == MouseButtons.Right)
            {
                // move to next day
            } 
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta == 120)
            {
                if (position > 1 && position <= count)
                    MoveToDay(--position);
            }
            else if (e.Delta == -120)
            {
                if (position >= 1 && position < count)
                    MoveToDay(++position);
            }
        }
    }
}
