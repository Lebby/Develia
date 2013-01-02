using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using System.IO;

namespace Develia.GUI.Themes.LD
{
    public class LDCommandButton : Layer
    {
        private Stream fileToLoad;
        private String path;
        private XButton xButton;
        private VButton vButton;
        private TipsButton tipsButton;

        public LDCommandButton()
        {            
            Console.WriteLine();
            init();
        }

        protected void init()
        {
            //fileToLoad = new StreamReader(path);
            //this.BackgroundImage = Texture2D.FromStream(this.GraphicsDevice,fileToLoad);
            xButton = new XButton();
            vButton = new VButton();
            tipsButton = new TipsButton();
            this.addComponent(xButton);
            this.addComponent(vButton); 
            this.addComponent(tipsButton);
        }

    }
}
