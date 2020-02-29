/*
 * Created by SharpDevelop.
 * User: Matyi
 * Date: 2020.01.23.
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using System.IO;

namespace deleteatcursorpro
{

	public partial class MainForm : Form
	{
		//constans to make the identification of certain elements easier
		public const int SName = 0;
		public const int SMod = 1;
		public const int SKey = 2;
		public string[] wrongkeys = {"None","Menu","ControlKey","ShiftKey",""};
		//variables used int the form
		public int type = 3;//what type of events will be deleted
		public bool split = false;//is splitting when deleting turned on or off
		public bool settkey = false;//are we modifying the settings, in the case of this script the shortcuts
		//variables for filehandling
		string savepath;
		string copypath;
		FileStream savefile;
		StreamReader fileread;
		StreamWriter filewrite;
		//variables for handling keyboard inputs/shortcuts
		string keymodact;//the currently selected modifier key (like control,shift,etc.) for the shortcut
		string keybaseact;//the currently selected main key (like A,B,1,etc.) for the shortcut
		string temp;
		public struct Shorts{//this structure will hold the individual shortcuts
			public string keyname;//the name of the function which the shortcut will activate
			public string keymod;//the modifier key
			public string keybase;//key main shortcut key
			public Shorts(string name, string mod, string basic){
				keyname = name;
				keymod = mod;
				keybase = basic;
			}
		}
		List<Shorts> shortcuts = new List<Shorts>();//this list will hold all of the shortcuts used in the script
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			//TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)//this is the first section that runs, happens when the windows opens up
		{
			this.Width = 312;
			cbb_selectshort.SelectedIndex = 0;
			savepath = Application.StartupPath + "\\script_shortcut.ini";//we set the savefiles location. It will be the scipt's location, plus the filename. 
			copypath = Application.StartupPath + "\\tempshortcut.ini";//the backup copy's location
			keymodact = "None";//resetting the currently selected modifier key 
			keybaseact = "None";//resetting the currently selected base key
			if (!File.Exists(savepath)){//if we don't have a shoortcut savefile, a default one is created
				savefile = new FileStream(savepath,FileMode.CreateNew);
				filewrite = new StreamWriter(savefile);
				filewrite.WriteLine("DeleteAtCursor");
				filewrite.WriteLine("Split;None;K");
				filewrite.WriteLine("Just Audio;None;U");
				filewrite.WriteLine("Just Video;None;I");
				filewrite.WriteLine("Video and Audio;None;O");
				filewrite.WriteLine("EndSection");
				filewrite.Close();
				savefile.Close();
			}
			savefile = new FileStream(savepath,FileMode.OpenOrCreate);//opening the savefile
			fileread = new StreamReader(savefile);
			//Reading in the shortcuts
			while (fileread.EndOfStream == false){//going through each line of the savefile
				temp = fileread.ReadLine();//reading it to a temporary variable
				string[] templist = temp.Split(';');//the savefile separates the different data in one line with a ; so we split the line to it's individual elements
				if (templist[SName] == "DeleteAtCursor"){//if we find the currently ued scripts section
					temp = fileread.ReadLine();
					templist = temp.Split(';');
					while (templist[SName] != "EndSection"){//we read in the data to the shortcut's variable until we reach the end of the script's section in the savefile
						shortcuts.Add(new Shorts(templist[SName],templist[SMod],templist[SKey]));
						temp = fileread.ReadLine();
						templist = temp.Split(';');
					}
					break;//we can end the reading because we've found our precious shortcuts
				}
			}
			fileread.Close();//we close the file
			savefile.Close();
		}
		
		void End_Script(){//closes the window
			split = chb_split.Checked;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		void Btn_terminateClick(object sender, EventArgs e)//closes the window when you press the button. Phew, this was hard to figure out.
		{
			End_Script();
		}
		void Btn_savekeyClick(object sender, EventArgs e)//runs when we try to save our custom shortcuts
		{
			bool keysok = true;//turns false if our custom shortcut is invalid
			foreach (string incorrect in wrongkeys) {//we check if the currently selected shortcut keys are valid
				if (incorrect == keybaseact){
					keysok = false;
				}
			}
			if (keysok == true){//if the keys are valid
				savefile = new FileStream(savepath,FileMode.OpenOrCreate);//we open the file, the create is there to avoid problems if we don't have a file. Wait... I'm not sure I thought it through
				fileread = new StreamReader(savefile);
				File.Copy(savepath,copypath,true);//we create  a copy of the shortcut file before doing anything, so we can restore it if needed
				//saving the keys in the file
				try{
					List<string> templist = new List<string>();
					//reading in every shortcut from the savefile to a temporary list
					while (fileread.EndOfStream != true) {
						templist.Add(fileread.ReadLine());
					}
					fileread.Close();
					savefile.Close();
					savefile = new FileStream(savepath,FileMode.Truncate);
					filewrite = new StreamWriter(savefile);
					//reading the lines from the temporary list, and if they are the script's shortcuts
					//we save them in the shortcuts list
					for (int i = 0; i < templist.Count;i++) {
						if (templist[i] == "DeleteAtCursor"){
							while (templist[i] != "EndSection"){
								string[] tempstring = templist[i].Split(';');
								if (tempstring[SName] == cbb_selectshort.GetItemText(cbb_selectshort.SelectedItem)){
									filewrite.WriteLine(tempstring[SName] + ";" + keymodact + ";" + keybaseact);
									for (int j = 0; j < shortcuts.Count; j++) {
										if (shortcuts[j].keyname == tempstring[SName]){
											shortcuts[j] = new Shorts(tempstring[SName],keymodact,keybaseact);
										}
									}
								}
								else{
									filewrite.WriteLine(templist[i]);
								}
								i++;
							}
							filewrite.WriteLine(templist[i]);
						}
						else{
							filewrite.WriteLine(templist[i]);
						}
					}
					filewrite.Close();
					savefile.Close();
					File.Delete(copypath);
				}
				catch (Exception exp){
					MessageBox.Show("Error while saving keyboard configuration: \n" + exp,"Error while saving",MessageBoxButtons.OK,MessageBoxIcon.Error);
					File.Copy(copypath,savepath,true);//if something goes wrong we restore the previously copied file
				}
			}
		}
		//Changing what type of events will be deleted
		void Rdb_type1Click(object sender, EventArgs e)
		{
			if (rdb_type1.Checked == true){
				type = 1;
			}
		}
		void Rdb_type2Click(object sender, EventArgs e)
		{
			if (rdb_type2.Checked == true){
				type = 2;
			}
		}
		void Rdb_type3Click(object sender, EventArgs e)
		{
			if (rdb_type3.Checked == true){
				type = 3;
			}
		}
		void Chb_splitCheckedChanged(object sender, EventArgs e)
		{
			split = chb_split.Checked;
		}
		//deciding what to do when (a) key is pressed 
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			//if the settings menu is NOT active
			if (settkey == false){
				if ((e.KeyCode.ToString() == shortcuts[0].keybase) && (e.Modifiers.ToString() == shortcuts[0].keymod)) {//split
						chb_split.Checked = !chb_split.Checked;
						split = !split;
				}
				else if ((e.KeyCode.ToString() == shortcuts[1].keybase) && (e.Modifiers.ToString() == shortcuts[1].keymod)) {//just audio
					rdb_type1.Checked = true;
					type = 1;
					End_Script();
				}
				else if ((e.KeyCode.ToString() == shortcuts[2].keybase) && (e.Modifiers.ToString() == shortcuts[2].keymod)) {//jsut video
					rdb_type2.Checked = true;
					type = 2;
					End_Script();
				}
				else if ((e.KeyCode.ToString() == shortcuts[3].keybase) && (e.Modifiers.ToString() == shortcuts[3].keymod)) {//both
					rdb_type3.Checked = true;
					type = 3;
					End_Script();
				}
			}
			//if it is
			else{
				keymodact = e.Modifiers.ToString();
				keybaseact = e.KeyCode.ToString();
				tbx_preview.Text = keymodact + " + " + keybaseact;
			}
			
		}
		//changing the background color of the settings button
		void Pbt_settingMouseEnter(object sender, EventArgs e)
		{
			pbt_setting.BackColor = SystemColors.Control;
		}
		void Pbt_settingMouseLeave(object sender, EventArgs e)
		{
			pbt_setting.BackColor = SystemColors.ControlDarkDark;
		}
		//opening 'n closing the settings menu
		void Pbt_settingClick(object sender, EventArgs e)
		{
			if (settkey == false){
				this.Width = 498;
			}
			else{
				this.Width = 312;
			}
			settkey = !settkey;
		}
		//switching the focus when the user selects an item
		void Cbb_selectshortSelectedIndexChanged(object sender, EventArgs e)
		{
			this.ActiveControl = btn_savekey;
		}

		

		


	}
	public class EntryPoint{
		
		bool vg_split = false;
		int vg_type = 3;
		DialogResult result;
		//opening the window and getting the values
		public void FromVegas(Vegas myVegas){
			using (MainForm form1 = new MainForm()){
				result = form1.ShowDialog();
				if (result == DialogResult.OK){
					vg_type = form1.type;
					vg_split = form1.split;
				}
			}
			//deleting every event under the cursor
			if (result == DialogResult.OK){
				foreach (Track myTrack in myVegas.Project.Tracks) {
					foreach (TrackEvent myEvent in myTrack.Events) {
						if ((myEvent.Start <= myVegas.Cursor) && (myEvent.End > myVegas.Cursor)){
							switch (vg_type) {
								case 1:
									if (myEvent.MediaType == MediaType.Audio){
										if ((vg_split == true) && (myEvent.Start != myVegas.Cursor)){
											AudioEvent newaud = (AudioEvent)myEvent.Split(myVegas.Cursor-myEvent.Start);
											myTrack.Events.Remove(newaud);
										}
										else{
											myTrack.Events.Remove(myEvent);
										}
									}
								break;
								case 2:
									if (myEvent.MediaType == MediaType.Video){
										if ((vg_split == true) && (myEvent.Start != myVegas.Cursor)){
											VideoEvent newvid = (VideoEvent)myEvent.Split(myVegas.Cursor-myEvent.Start);
											myTrack.Events.Remove(newvid);
										}
										else{
											myTrack.Events.Remove(myEvent);
										}
									}
								break;
								case 3:
									if ((vg_split == true) && (myEvent.Start != myVegas.Cursor)){
										TrackEvent newevent = myEvent.Split(myVegas.Cursor-myEvent.Start);
										myTrack.Events.Remove(newevent);
									}
									else{
										myTrack.Events.Remove(myEvent);
									}
								break;
								default:
									MessageBox.Show("No event type selected. Select video, audio or both!","TypeError",MessageBoxButtons.OK,MessageBoxIcon.Error);
								break;
							}
						}
					}
				}
			}
		}
	}

}
