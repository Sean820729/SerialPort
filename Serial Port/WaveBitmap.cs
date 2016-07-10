using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PPG_debug_tool
{
    public class WaveBitmap
    {
        public Bitmap BitmapSource = null;
        public Graphics GraphSource = null;
        private Pen m_DrawPen;
        //---------------------------------------------
        private int BitmapWidth = 0;        //Bitmap寬度
        private int BitmapHeight = 0;       //Bitmap高度  
        private int BitmapRange = 0;     //範圍從0~4095   正
        private int BitmapCenter = 0;
        //---------------------------------------------        
        private int Section = 0;            //一次顯示區塊數，一個區塊表示一秒鐘
        private int SourcePerX = 0;         //前一次的座標X值
        private int SourcePerY = 0;         //紀錄前一次的Y值
        //------------------------------------
        private PictureBox picbox;
        //------------------------------------
        Graphics GraphFrame;
        Bitmap FrameBitmap;
        //------------------------------------






        public WaveBitmap(Color DrawPenColor, int Y_Range_Low, int Y_Range_Up, int FrameSection, ref PictureBox Pic)
        {
            //----------------------------------------------            
            BitmapWidth = Pic.Width;
            BitmapHeight = Pic.Height;

            BitmapSource = new Bitmap(BitmapWidth, BitmapHeight);
            //----------------------------------------------
            BitmapRange = Y_Range_Up - Y_Range_Low + 1;
            BitmapCenter = (Y_Range_Up + Y_Range_Low + 1) / 2;

            SourcePerY = ConvertY(BitmapCenter);
            //-----------------------------------------------
            Section = FrameSection;
            m_DrawPen = new Pen(DrawPenColor, 1);
            picbox = Pic;
            //-----------------------------------------------------------------
            GraphSource = Graphics.FromImage(BitmapSource);
            //----------------------------------------------------------------- 
            //-----------------------------------------------------------------
            picbox.Paint += new System.Windows.Forms.PaintEventHandler(picbox_Paint);

            //背景格線========================================================

            FrameBitmap = new Bitmap(BitmapWidth, BitmapHeight);
            GraphFrame = Graphics.FromImage(FrameBitmap);
            DrawFrame();

        }

        private int Value_X = 0;



        private int ConvertY(int temp)
        {



            int ConvertValue = (int)((temp - BitmapCenter + BitmapRange / 2) * (BitmapHeight-3) / BitmapRange);   // 轉成比例值
            ConvertValue = ConvertValue * (-1) + (BitmapHeight - 3);     //轉成以左下角為原點，向上為正


            return ConvertValue;



        }

        public int Det_X = 0;
        public int Det_Y = 0;



        private void DrawFrame()            //不能先畫       座標很容易亂掉
        {
            GraphFrame.Clear(Color.FloralWhite);   //背景顏色

            int Value_Y = ConvertY(BitmapCenter);


            GraphFrame.DrawLine(Pens.Gray, 0, Value_Y, BitmapWidth, Value_Y);   //畫水平中線
            //---------------------------------------------------------------------------
            for (int i = 1; i < Section; i++)
            {
                int tempX = BitmapWidth * i / Section - 1;

                GraphFrame.DrawLine(Pens.Gray, tempX, 0, tempX, BitmapHeight + 1);   //畫圖
            }

            Rectangle srcRectangle = new Rectangle(Value_X, 0, BitmapWidth, BitmapHeight); //來源
            Rectangle destRectangel = new Rectangle(Value_X, 0, BitmapWidth, BitmapHeight); //目的   註解掉反轉可以


            GraphSource.DrawImage(FrameBitmap, destRectangel, srcRectangle, GraphicsUnit.Pixel);
        }


        public void DrawPixel(int value)
        {
            //DrawDetection(Det_X,Det_Y);

            if (SourcePerX == (BitmapWidth - 1))       //重劃
            {
                SourcePerX = 0;
                Value_X = 0;
            }
            //--------------------------------------------------------------------------------------
            int Value_Y = ConvertY(value);      //要畫得值

            //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
            //將之前畫面清掉
            Rectangle srcRectangle = new Rectangle(Value_X, 0, 30, BitmapHeight); //來源
            Rectangle destRectangel = new Rectangle(Value_X, 0, 30, BitmapHeight); //目的   註解掉反轉可以


            GraphSource.DrawImage(FrameBitmap, destRectangel, srcRectangle, GraphicsUnit.Pixel);


            //-------------------------------------------------------------------------------
            GraphSource.DrawLine(m_DrawPen, SourcePerX, SourcePerY, Value_X, Value_Y);   //畫圖    
            //============================================================================
            SourcePerY = Value_Y;
            SourcePerX = Value_X;
            //--------------------------
            Value_X++;
            //--------------------------------------------------------------------------------
            picbox.Invalidate();
        }


        //----------------------------------------------------------------------------
        public void DrawArray(byte[] tempArray)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                int value = Convert.ToInt32(tempArray[i]);
                DrawPixel(value);
            }
        }
        //-------------------------------------------------------
        private void picbox_Paint(object sender, PaintEventArgs e)
        {

            //------------------------------------------------
            e.Graphics.DrawImage(BitmapSource, new Point(0, 0));     //可以指定位置
        }
        //-------------------------------------------------------




    }
}
