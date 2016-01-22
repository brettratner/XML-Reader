Created by: Brett Ratner
The resxDataExtracter program is set with default parameters of looking for the files to extract from in your "C:/"drive and will create the excel files in your "C:/" drive. 

To change the default location open "spoon.bat" to open up the kettle application then right click.
-->	Click on Transformation settings(CTRL-T)
	--> Click on the Parameters tab at the top of the Transformation settings window
		--> Change Default Value for DEST_DIR(Destination Directory of the excel file) and for SCR_DIR(Source Directory of where it will look for all the files)
			-->Click Ok to save changes


To run the project click the arrow in the top left corrner, and Inside the Execute a transformation window 
	--> set the value of the DEST_DIR and SRC_DIR (if necessary) and click Launch
