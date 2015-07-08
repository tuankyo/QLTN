using System;
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Man.Utils
{
    public enum TextAlignment 
    { 
        Left = 0,
        Center = 1,
        Right = 2        
    }

    public class JapaneseFont
    {

        public JapaneseFont()
        {

        }

        public BaseFont MS_Gothic
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, true); }
            get { return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, true); }            
        }

        public BaseFont MS_PGothic
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, true); }
            get { return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, true); }            
        }
        public BaseFont MS_UIGothic
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msgothic.ttc,2", BaseFont.IDENTITY_H, true); }
            get { return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\msgothic.ttc,2", BaseFont.IDENTITY_H, true); }            
        }
        public BaseFont MS_Mincho
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msmincho.ttc,0", BaseFont.IDENTITY_H, true); }
            get { return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\msmincho.ttc,0", BaseFont.IDENTITY_H, true); }
        }
        public BaseFont MS_PMincho
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msmincho.ttc,1", BaseFont.IDENTITY_H, true); }
            get { return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\msmincho.ttc,1", BaseFont.IDENTITY_H, true); }
        }
        public BaseFont Arial
        {
            //get { return BaseFont.CreateFont(ICJSystem.Instance.ApplicationPath + @"Fonts\msmincho.ttc,1", BaseFont.IDENTITY_H, true); }
            get
            {
                return BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            }
        }
    }

    public class IcjDocument
    {
        private Document document = null;
        private PdfWriter writer = null;
        private PdfContentByte contentByte = null;        
        private ColumnText columnText = null;
        private MemoryStream stream = null;
        private float width = 0;
        private float height = 0;              

        private float marginLeft = 0;
        private float marginRight = 0;
        private float marginTop = 0;
        private float marginBottom = 0;
        
        private string fileName  = string.Empty;

        private iTextSharp.text.Image jpg = null;

        public IcjDocument()
        {
            document = new Document();  
        }
        public IcjDocument(string fileName,FileMode fileMode, string output, int marginLeft,int marginRight,int marginTop,int marginBottom)
        {           
            document = new Document(PageSize.A4,marginLeft,marginRight,marginTop,marginBottom);
            this.marginLeft = marginLeft;
            this.marginRight = marginRight;
            this.marginTop = marginTop;
            this.marginBottom = marginBottom;    
            if (File.Exists(fileName)) 
            {
                File.Delete(fileName);
            }
            if (output == "file")
            {
                writer = PdfWriter.GetInstance(document, new FileStream(fileName, fileMode));
            }
            else if (output == "memory")
            {
                stream = new MemoryStream();
                writer = PdfWriter.GetInstance(document, stream);
            }
            width = PageSize.A4.Width-marginLeft-marginRight ;
            height = PageSize.A4.Height-marginTop-marginBottom;  
        }
        public IcjDocument(string logoFile, string fileName, FileMode fileMode, string output, int marginLeft, int marginRight, int marginTop, int marginBottom)
        {
            document = new Document(PageSize.A4, marginLeft, marginRight, marginTop, marginBottom);
            this.marginLeft = marginLeft;
            this.marginRight = marginRight;
            this.marginTop = marginTop;
            this.marginBottom = marginBottom;
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            if (output == "file")
            {
                writer = PdfWriter.GetInstance(document, new FileStream(fileName, fileMode));
            }
            else if (output == "memory")
            {
                stream = new MemoryStream();
                writer = PdfWriter.GetInstance(document, stream);
            }
            width = PageSize.A4.Width - marginLeft - marginRight;
            height = PageSize.A4.Height - marginTop - marginBottom;

            jpg = iTextSharp.text.Image.GetInstance(logoFile);

            //Resize image depend upon your need
            //For give the size to image
            //jpg.ScaleToFit(2500, 500);

            //If you want to choose image as background then,

            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;

            //If you want to give absolute/specified fix position to image.
            jpg.SetAbsolutePosition(15, 40);
            

        }
        public void AddLogo()
        {
            try
            {
                document.Add(jpg);
            }
            catch (DocumentException de)
            {
                ApplicationLog.WriteError(de);
            }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float MarginLeft
        {
            get{return this.marginLeft;}
            set{this.marginLeft=value;}
        }

        public float MarginRight
        {
            get{return this.marginRight;}
            set{this.marginRight=value;}
        }

        public float MarginTop
        {
            get{return this.marginTop;}
            set{this.marginTop = value;}
        }

        public float MarginBottom
        {
            get{return this.MarginBottom;}
            set{this.MarginBottom=value;}
        }

        public MemoryStream Stream
        {
            get { return this.stream; }
        }
        
        public void Open()
        {
            try
            {                         
                document.Open();
                AddLogo();
                contentByte = writer.DirectContent;  
            }catch(DocumentException de)
            {
                ApplicationLog.WriteError(de);
            }            
        }

        public void BeginTextBox(float x,float y,float w,float h)
        {            
            columnText = new ColumnText(contentByte);
            columnText.SetSimpleColumn(x+marginLeft, PageSize.A4.Height - marginTop-y, x +marginLeft+ w, PageSize.A4.Height -marginTop-y-h);                                                            
        }      

        public void AddBoxTextLine(string text, Font font,int align)
        {
            Paragraph p = new Paragraph(text, font);                      
            p.SpacingAfter = 0;
            p.SpacingAfter = 0;            
            p.Alignment = (int)align;            
            columnText.AddElement(p);            
        }
                
        public int EndTextBox()
        {
            return columnText.Go();
        }

        public void AddTableEx(PdfPTable table,float x,float y,float w,float h)
        {
            BeginTextBox(x,y,w,h);
            columnText.AddElement(table);
            EndTextBox();            
        }

        public void AddHeader(HeaderFooter header)
        {
            document.Header = header;
        }

        public void AddFooter(HeaderFooter footer)
        {
            document.Footer = footer;
        }

        public int GetPageNumber()
        {
            return document.PageNumber;
        }

        public int GetPageNumberFromWriter()
        {
            return writer.PageNumber;
        }

        public bool Add(IElement element)
        {
            return document.Add(element);
        }

        public bool NewPage()
        {
            AddLogo();
            return document.NewPage();
        }
             
        public void Close()
        {
            document.Close();
        }

        //************TEST****************
        public void Test()
        {
            writer.Add(new Paragraph("aaa"));           
            writer.Flush();
            document.Close();
        }
        //*********************************
    }
}
