using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class script : MonoBehaviour {
	public Image panelImage;

	// Use this for initialization
	public void Process () {
		panelImage.color=Color.white;

		string content = GUIUtility.systemCopyBuffer;
		string[] splitString = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

		//Debug.Log(splitString[splitString.Length-2]);
		string outputString = "";
		string temporaryString = "";
		int lastStrokeEventStartline=-1;
		bool strokeJustFinished=false;
		bool insideStroke=false;

		Debug.Log("lines "+splitString.Length);
		for(int i = 0;i<splitString.Length;i++){
			// go through each line
			if(strokeJustFinished){
				strokeJustFinished=false;
				insideStroke=false;
				if(splitString[i].Length > 4 && splitString[i].Substring(splitString[i].Length-4,4) == "Undo"){
					Debug.Log("undo detected");
					Debug.Log("discarding: "+temporaryString);
					temporaryString="";
					continue;
				} else {
					outputString += temporaryString;
					temporaryString="";
				}
			}
			if(splitString[i]=="<StrokeEvent>"){
				insideStroke=true;
			}
			if(insideStroke){
				temporaryString += splitString[i]+"\n";
			} else{
				outputString += splitString[i]+"\n";
			}
			if(splitString[i]=="</StrokeEvent>"){
				strokeJustFinished=true;
				insideStroke=false;
			} else {
				strokeJustFinished=false;
			}
		}
		GUIUtility.systemCopyBuffer = outputString;
		Debug.Log("copied a stripped version of the script to the clipboard");
		panelImage.color=Color.green;
	}
}
