/*
 * Created by SharpDevelop.
 * User: Kerry
 * Date: 9/30/2016
 * Time: 8:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Crawfish
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		WebBrowser webTab;
		
		
		
		
		
		

    	
	

		
		
		
		
		
		
		
		
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			
			
			WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
			if(web != null){
				web.Navigate(textBox1.Text);
			}
		}
		
		
		
		
		
		
		
		//--------------------------------------------------------------------
		// Back button events
		
		void Button2Click(object sender, EventArgs e)
		{
			WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
			if(web != null){
				
				if(web.CanGoBack){
					web.GoBack();
				}
				
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
			if(web != null){
				
				if(web.CanGoForward){
					web.GoForward();
				}
				
			}
			
			
			
		}
		void Button4Click(object sender, EventArgs e)
		{
			webBrowser1.GoHome();
		}
		
		void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
		}
		
		//------------------------------------------------------------------
		
		void MainFormLoad(object sender, EventArgs e)
		{
			webBrowser1.Navigate("https://www.google.com/");
			webBrowser1.DocumentCompleted += WebBrowser1DocumentCompleted;
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			TabPage tab = new TabPage();
			tab.Text = "New Tab";
			tabControl1.Controls.Add(tab);
			tabControl1.SelectTab(tabControl1.TabCount - 1);
			webTab = new WebBrowser() {
				ScriptErrorsSuppressed = false
			};
			webTab.Parent = tab;
			webTab.Dock = DockStyle.Fill;
			webTab.Navigate("https://www.google.com/");
			webTab.DocumentCompleted += WebTabDocumentCompleted;
			
				
		}
		private void WebTabDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){
			
			tabControl1.SelectedTab.Text = webTab.DocumentTitle;
			
		}
		private void TextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
				if(web != null){
					web.Navigate(textBox1.Text);
				}
			}
		}

	}
}
