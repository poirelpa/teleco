# teleco
Remote control for my Raspberry pi, my TV and my Freebox (french Internet Provider media player)

This is not finalized, and probably won't be finalized ...
But it works for me ...




Requirements on server :

https://github.com/haikuginger/kodipydent

https://github.com/MaximeCheramy/remotefreebox


## Server
The server is a python script running with Flask.

I installed it as a service on my raspberry pi with supervisorctl

The server runs on port 8081.

### HTML client
Default route returns a HTML remote control :

![HTML client](images/html_client.png)

### Freebox
/freebox/<key> is mapped to a method that uses remotefreebox to press the button.

When the freebox restarts, the control api starts on a random port, discoverd by the freeboxcontroller module.

A call to /freebox/power tries to start the freebox with the already started freeboxcontroller, then restarts the freeboxcontroller in case the port has changed.

### Kodi
/kodi/<key> is mapped to a method that uses kodi JSONRPC API (Application.Quit, or Input.ExecuteAction)

/kodi/start launches kodi if it is not already started.

### TV
/hdmi/<key> is mapped to a method that launches CEC commands on HDMI.

My Freebox is on HDMI 3, and my PI is on HDMI 2.


## Client

The Android client is coded in .NET C#.

![Android client](images/android_client.png)

There is some code in it to work with the IR emitter of the phone if needed, but I have since switched TV controls to CEC/HDMI, so I do not need the IR anymore.
