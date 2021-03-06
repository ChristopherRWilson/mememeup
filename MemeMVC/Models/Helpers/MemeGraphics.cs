﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace MemeMeUp.Models.Helpers
{
    public class MemeGraphics
    {
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public static Image OverlayText(Image image, string text, bool OnTop)
        {
            text = MemeMeUp.Models.Helpers.MemeText.SplitSentence(text);
            float fontSize = 10;
            SizeF textSize = new SizeF();
            Pen p = new Pen(Brushes.Black, 6);
            GraphicsPath gp = new GraphicsPath();
            Rectangle r = new Rectangle(0, 0, image.Width, image.Height);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;

            Font myFont = new Font("Impact", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            Graphics bmImage = Graphics.FromImage(image);

            for (int i = 10; i < 100; i++)
            {
                myFont = new Font("Impact", (float)i);
                textSize = bmImage.MeasureString(text, myFont);
                fontSize = i;
                if (textSize.Width > image.Width)
                    break;
            }

            if (OnTop)
                sf.LineAlignment = StringAlignment.Near;

            gp.AddString(text, myFont.FontFamily, (int)FontStyle.Bold, myFont.SizeInPoints, r, sf);

            p.LineJoin = LineJoin.Round;
            bmImage.SmoothingMode = SmoothingMode.HighQuality;
            bmImage.PixelOffsetMode = PixelOffsetMode.HighQuality;
            bmImage.DrawPath(p, gp);
            bmImage.FillPath(Brushes.White, gp);
            
            bmImage.Dispose();
            p.Dispose();
            gp.Dispose();

            return image;
        }
    }
}