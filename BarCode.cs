using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Euresys.Open_eVision_2_6;

namespace BrcReading
{

	public class MainForm : System.Windows.Forms.Form
	{
  
        private EImageBW8 m_Source= new EImageBW8();
        private EBarCode m_BarCode= new EBarCode();

        private string m_DecodedText= "";

        private Font m_Font= new Font("Arial", 9);
        private Brush m_BlackBrush= new SolidBrush(Color.Black);
        private Brush m_WhiteBrush= new SolidBrush(Color.White);

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem fileLoadMenu;
        private System.Windows.Forms.MenuItem fileExitMenu;
        private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem ApplicationIntroduction;

		private System.ComponentModel.Container components = null;

		public MainForm()
		{
		
			InitializeComponent();

	
			ApplicationIntroduction_Click(null, null);
		}

		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


	
		private void InitializeComponent()
		{
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.fileLoadMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.fileExitMenu = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.ApplicationIntroduction = new System.Windows.Forms.MenuItem();
			
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem3});
	
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileLoadMenu,
																					  this.menuItem2,
																					  this.fileExitMenu});
			this.menuItem1.Text = "File";
			
			this.fileLoadMenu.Index = 0;
			this.fileLoadMenu.Text = "Load";
			this.fileLoadMenu.Click += new System.EventHandler(this.fileLoadMenu_Click);
			
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
		 
			this.fileExitMenu.Index = 2;
			this.fileExitMenu.Text = "Exit";
			this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
			
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ApplicationIntroduction});
			this.menuItem3.Text = "Help";
		
			this.ApplicationIntroduction.Index = 0;
			this.ApplicationIntroduction.Text = "Application Introduction...";
			this.ApplicationIntroduction.Click += new System.EventHandler(this.ApplicationIntroduction_Click);
		
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 590);
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "BrcReading";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Closed += new System.EventHandler(this.MainForm_Closed);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);

		}
		#endregion

	
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}


    private void MainForm_Load(object sender, System.EventArgs e)
    {

      m_BarCode.StandardSymbologies = (int)ESymbologies.Standard;
      m_BarCode.AdditionalSymbologies = (int)ESymbologies.Additional;
    }


    private void fileLoadMenu_Click(object sender, System.EventArgs e)
    {
 
      openFileDialog.Filter= "Image Files (*.tif;*.jpg;*.bmp)|*.tif;*.jpg;*.bmp";
      if(openFileDialog.ShowDialog() == DialogResult.Cancel)
      {
    
        return;
      }

      try
      {

        m_Source.Load(openFileDialog.FileName);   
   
        
        m_DecodedText = m_BarCode.Read(m_Source);
      }
      catch(EException exc)
      {
        m_DecodedText = "Error while decoding";
        MessageBox.Show(exc.Message);
      }

  
      Refresh();

    }


    private void fileExitMenu_Click(object sender, System.EventArgs e)
    {

      Close();
    }


    private void DrawBackedText(Graphics g, string text, int x, int y)
    {
      SizeF size= g.MeasureString(text, m_Font);

      g.FillRectangle(m_WhiteBrush, x, y, size.Width, size.Height);
      g.DrawString(text, m_Font, m_BlackBrush, x, y);      
    }


    private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
    
      if (m_Source.IsVoid)
        return;

  
      m_Source.Draw(e.Graphics);
	

      m_BarCode.Draw(e.Graphics, EDrawingMode.Actual);
	

      DrawBackedText(e.Graphics, m_DecodedText, 10, 10);

    }

    private void MainForm_Closed(object sender, System.EventArgs e)
    {
    }

	private void ApplicationIntroduction_Click(object sender, System.EventArgs e)
	{
		MessageBox.Show(
			@"Required license: EasyBarCode",
			"BrcReading",
			MessageBoxButtons.OK, MessageBoxIcon.Information);
	}
	}
}
