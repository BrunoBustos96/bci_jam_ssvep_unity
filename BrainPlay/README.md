This Applet implements basic two way communication between an integrated Unity WebGL build and the B@P library API.


## The environment and how everything connects
This Applet uses only some of the available EEG/whatever other kind of biofeedback features that you can hook up to your game implementation. These are hooked in from the Atlas.

To communicate a feature data variable to the Unity game, the applet has to send a message to the Unity build, addressing it to a GameObject in the hierarchy to which the BCIDataListener is attached to. f.e.:
	"this.props.instance.SendMessage('GameApplication', 'UpdateBlink', blink);"
If you want to rename the game object in the project hierarchy, this call has to reflect that.
The second parameter is the function name that updates the Unity game logic and also has to correspond by name exactly.
Third parameter is the value for that function.

Look for the currently supported feature list in EEGData.cs in the Unity project.

If you want to hook in and use another feature from the Atlas, you have to do the following:
1) Add it to the EEGData.cs data struct.
2) Add the function to process the feature in Unity BCIListener.cs.
3) In the settings.js, add definitions to the feature you want to send to Unity to the commands and edges list.


BCIDataListener implements a platform dependent interface that either listens to messages coming from the server.

DataSender is the script that sends event from Unity to the WEB server.
To add adittional send methods you have to do the following:
1) Add a function callback to the .jslib plugin file. This will compile during the build and you will then use JSPlugin.cs to call methods from .jslib to invoke events on the web window context when running the build.
2) Add a call to the JSPlugin.cs.
3) Add the method to the Unity.js window context.


## The build Process
## Unity
1. Clone the UnityBrainsAtPlayTemplate project.
2. Create your scene. Make sure that there is one game object in your scene that has the BCIDataListener on it.
3. Create your own objects and scripts and refer to the BCIDataListener instance for eeg data when you need to.
4. Feel free to create your own architectures the way you see fit as this is just an example.


### Applet
1. Copy the Unity Applet template.
2. Build your Unity project. (make sure the platform is set to webgl)
3. Copy over the Build and TemplateData folders from your build into the template. Make sure you do not delete the buildconfig.js.
4. Open the webbuild.loader.js file and make sure that the very top line 'function createUnityInstance' has the word 'export' in front of it. Then go to line 180 where canvas object is created. Some versions of Unity wont have the gl rendercontext object defined here, so right before the line that goes 'if (canvas) {...}', copy in this line: 'let gl, glVersion;'
5. Now open up the UnityApplet.js and go to the init() function, find where webbuild calls createUnityInstance(). In its' callback we start an animate method which fetches all the eeg data from the Atlas and sends it over to your gameobject that has the BCIDataListener script on it.
6. In the SendMessage call, you have to make sure that the first parameter is the name of that game object ans not the script. And then the corresponding update method call is universal for your BCIDataListener. Unless you renamed it.


## Notes
* make sure the build is set to Development in the project build settings, otherwise the loader.js will get ultra optimized and you wont be able to edit it. This might be version specific, but just in case.


## Important for Chrome Users
Make sure that your hardware rendering is turned on under Settings > Advanced > System
Then Go to chrome://flags in your browser
Ensure that Disable WebGL is not activated