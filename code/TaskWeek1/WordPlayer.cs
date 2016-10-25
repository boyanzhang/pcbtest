using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Drawing;

namespace TaskWeek1
{
    class WordPlayer
    {     
        #region-属性-
        private static object Nothing = System.Reflection.Missing.Value;
        private static Word._Application oWord = null;
        private static Word._Document odoc = null;
         private static Word._Document oDoc       { 
             get{
                 if(odoc==null)
                 {
                     odoc = oWord.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                 }
                 return odoc;
             }
             set{
                 if (value != null)
                 {
                     odoc = value;
                 }
             }

         }
        public enum Orientation
        { 
        横版,
        竖版
        }
        public enum Alignment
        { 
        左对齐,居中对齐,右对齐
        }
        #endregion
        #region-创建一个Word文档进行编辑-
        public static void  OpenNewWordFileToEdi()
        {
           oDoc=oWord.Documents.Add(ref Nothing,ref Nothing,ref Nothing ,ref Nothing);

    }
        #endregion
        #region-创建Word-
        public static bool CreateWord (bool isVisiable)
        {
            try
            {
                oWord = new Word.Application();
                oWord.Visible = isVisiable;
                return true;
            }
            catch(Exception)
            {
                return false ;
            }
        } 
        public static bool CreateWord()
        {
        return CreateWord(false);
        }
        #endregion
        #region-OpenFile-
        public static bool OpenFile(string filePath, bool isVisiable) 
        {
            try
            {
                oWord.Visible = isVisiable;
                object path = filePath;
                oDoc=oWord.Documents.Open(ref path,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region-InsertTable-
        public static bool InsertTable(DataTable dt,bool haveBorder,double[] colWidths,string[] title)
        {
            try
            {
                object Nothing = System.Reflection.Missing.Value;
                int Length = oDoc.Characters.Count-1;
                object start = Length;
                object end = Length;
                Word.Range tableLocation = oDoc.Range(ref start, ref end);//设置表格起始位置
                Word.Table table = oDoc.Tables.Add(tableLocation, dt.Rows.Count+1, dt.Columns.Count+1, ref Nothing, ref Nothing);
                //设置表格列的宽度
                if (colWidths != null)
                {
                    for (int i = 0; i < colWidths.Length; i++)
                    {
                        table.Columns[i + 1].Width = (float)(28.5F * colWidths[i]);
                    }
                }
                //设置表格格式
                table.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAtLeast;
                table.Rows.Height = oWord.CentimetersToPoints(float.Parse("0.8"));
                table.Range.Font.Size = 10.5f;
                table.Range.Font.Name = "宋体";
                table.Range.Font.Bold = 0;//加粗选项
                table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //设置外框格式
                if (haveBorder == true)
                {
                    table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                }
                //添加数据

                if (title != null)//添加表格头
                {
                    for (int i = 0; i < title.Length; i++)
                    {
                        table.Cell(1, i+1).Range.Text = title[i];
                    }
                }
                for (int i = 0; i < dt.Columns.Count+1; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        table.Cell(j+2 , 1).Range.Text = (j + 1).ToString();
                        table.Cell(j +2, i + 2).Range.Text = dt.Rows[j][i].ToString();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool InsertTable(DataTable dt, bool haveBorder)
        {
            return InsertTable(dt, true, null,null);
        }
        public static bool InsertTable(DataTable dt)
        {
            return InsertTable(dt, false, null,null);
        }
        #endregion
        #region-插入文本-
        public static bool InsertText(string strText,System.Drawing.Font font,Alignment alignment,bool isAftre)
        {
            try
            {
                Word.Range rng = oDoc.Content;
                int lenght = oDoc.Characters.Count-1;
                object start = lenght;
                object end = lenght;
                rng = oDoc.Range(ref start, ref end);
                if (isAftre == true)
                {
                    strText += "\r\n";
                }
                rng.Text = strText;
                rng.Font.Size = font.Size;
                rng.Font.Name = font.Name;
                if (font.Style == FontStyle.Bold) { rng.Font.Bold = 1; }
                SetAlignment(rng, alignment);//设置
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public static bool InsertText(string str)
        {
            return InsertText(str, new System.Drawing.Font("宋体", 10.5F, FontStyle.Bold), Alignment.右对齐, true);
        }
        #endregion
        #region-设置对齐方式-
        private static Microsoft.Office.Interop.Word.WdParagraphAlignment SetAlignment(Word.Range rng, Alignment alignment)
        {
            rng.ParagraphFormat.Alignment = SetAlignment(alignment);
            return SetAlignment(alignment);
        }
        private static Microsoft.Office.Interop.Word.WdParagraphAlignment SetAlignment(Alignment alignment)
        {
            if (alignment == Alignment.居中对齐)
            {
                return Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else if (alignment == Alignment.左对齐)
            {
                return Word.WdParagraphAlignment.wdAlignParagraphLeft;
            }
            else
            { return Word.WdParagraphAlignment.wdAlignParagraphRight; }
        }
        #endregion
        #region-页面设置-
        public static void SetPage(Orientation orientation, double width, double height, double topMargin, double leftMargin, double rightMargin, double bottomMargin)
        {
            oDoc.PageSetup.PageWidth = oWord.CentimetersToPoints((float)width);
            oDoc.PageSetup.PageHeight = oWord.CentimetersToPoints((float)height);
            if (orientation == Orientation.横版)
            {
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            }
            oDoc.PageSetup.TopMargin = (float)(topMargin*25);
            oDoc.PageSetup.BottomMargin = (float)(bottomMargin * 25);
            oDoc.PageSetup.LeftMargin = (float)(leftMargin * 25);
            oDoc.PageSetup.RightMargin = (float)(rightMargin * 25);
        }
        public static void SetPage(Orientation orientation, double topMargin, double leftMargin, double rightMargin, double bottomMargin)
        {
            SetPage(orientation, 21, 29.7, topMargin, leftMargin, rightMargin, bottomMargin);
        }
        public static void SetPage(double topMargin, double leftMargin, double rightMargin, double bottomMargin)
        {
             SetPage(Orientation.竖版, 21, 29.7, topMargin, leftMargin, rightMargin, bottomMargin);
        }
        #endregion
        #region-插入分页符-
        public static void InsertBreak()
        {
            Word.Paragraph para;
            para = oDoc.Content.Paragraphs.Add(ref Nothing);
            object pBreak = (int)Word.WdBreakType.wdSectionBreakNextPage;
            para.Range.InsertBreak(ref pBreak);
        }
        #endregion
        #region-关闭当前文档-
        public static bool CloseDocument()
        {
            try
            {
                object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                oDoc.Close(ref doNotSaveChanges, ref Nothing, ref Nothing);
                oDoc = null;
                odoc = null; //清除文档数据
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region - 关闭程序 -
        public static bool Quit()
        {
            try
            {
                object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                oWord.Quit(ref saveOption, ref Nothing, ref Nothing);
                oWord = null; 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region-SaveFile-
        public static bool Save(string savePath)
        {
            return Save(savePath, false);
        }
        public static bool Save(string savePath, bool isClose)
        {
            try
            {
                object fileName = savePath;
                oDoc.SaveAs(ref fileName, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                if (isClose)
                {
                    return CloseDocument();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region - 插入页脚 -
        public static bool InsertPageFooter(string text, System.Drawing.Font font, Alignment alignment)
        {
            try
            {
                oWord.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;//页脚 
                oWord.Selection.InsertAfter(text);
                GetWordFont(oWord.Selection.Font, font);

                SetAlignment(oWord.Selection.Range, alignment);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool InsertPageFooterNumber(System.Drawing.Font font, Alignment alignment)
        {
            try
            {
                oWord.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
                oWord.Selection.WholeStory();
                oWord.Selection.ParagraphFormat.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                oWord.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;

                oWord.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;//页脚 
                oWord.Selection.TypeText("第");

                object page = Word.WdFieldType.wdFieldPage;
                oWord.Selection.Fields.Add(oWord.Selection.Range, ref page, ref Nothing, ref Nothing);

                oWord.Selection.TypeText("页/共");
                object pages = Word.WdFieldType.wdFieldNumPages;

                oWord.Selection.Fields.Add(oWord.Selection.Range, ref pages, ref Nothing, ref Nothing);
                oWord.Selection.TypeText("页");

                GetWordFont(oWord.Selection.Font, font);
                SetAlignment(oWord.Selection.Range, alignment);
                oWord.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region - 字体格式设定 -
        public static void GetWordFont(Microsoft.Office.Interop.Word.Font wordFont, System.Drawing.Font font)
        {
            wordFont.Name = font.Name;
            wordFont.Size = font.Size;
            if (font.Bold) { wordFont.Bold = 1; }
            if (font.Italic) { wordFont.Italic = 1; }
            if (font.Underline == true)
            {
                wordFont.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            wordFont.UnderlineColor = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

            if (font.Strikeout)
            {
                wordFont.StrikeThrough = 1;//删除线
            }
        }
        #endregion
        #region - 获取Word中的颜色 -
        public static Word.WdColor GetWordColor(Color c)
        {
            UInt32 R = 0x1, G = 0x100, B = 0x10000;
            return (Microsoft.Office.Interop.Word.WdColor)(R * c.R + G * c.G + B * c.B);
        }
        #endregion
    }
}
