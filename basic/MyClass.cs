using System;
using System.Collections.Generic;
using ScriptPortal.Vegas;

namespace deleteatcursor
{
	/// <summary>
	/// This script deletes every event under the cursor in Vegas Pro
	/// </summary>
	public class EntryPoint{
		public void FromVegas(Vegas myVegas){
			try{
				foreach (Track myTrack in myVegas.Project.Tracks){//goes through each track's each event
					foreach (TrackEvent myEvent in myTrack.Events) {
						if ((myEvent.Start.FrameCount <= myVegas.Cursor.FrameCount) && (myEvent.End.FrameCount > myVegas.Cursor.FrameCount)){//if the event is under the cursor, or starts at the cursor
							myTrack.Events.Remove(myEvent);//it gets removed
						}
					}
				}
			}
			catch{
				
			}
		}
	}
}