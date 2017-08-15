#!/usr/bin/python3
from flask import Flask, render_template, send_from_directory, request
from remotefreebox.freeboxcontroller import FreeboxController
from pycurl import Curl
from urllib.parse import urlencode
import os

app = Flask(__name__, static_folder='static')
fbx = FreeboxController()
curl = Curl()
#curl.setopt(curl.URL, "http://127.0.0.1:8080/jsonrpc")
#curl.setopt(curl.POST, True)
curl.setopt(curl.VERBOSE, True)
#curl.setopt(curl.HTTPHEADER, ["Content-type: application/json"])

@app.route('/')
def index():
    return render_template('teleco.html')

@app.route('/freebox/<path:key>')
def freebox(key):
    global fbx
    fbx.press(key)
    if key == 'Power':
        fbx = FreeboxController()
    return render_template('teleco.html')

@app.route('/kodi/<key>')
def kodi(key):
    if key == 'start':
        os.system("/home/pi/teleco/launch_kodi_once.sh &")
        return render_template('teleco.html')
    elif key == 'Quit':
        a = '{"jsonrpc":"2.0","method":"Application.Quit"}'
    else: 
        a = '{"jsonrpc":"2.0","method":"Input.ExecuteAction","params":{"action":"' + key + '"}}'
    #curl.setopt(curl.HTTPPOST, a)
    curl.setopt(curl.URL, "http://127.0.0.1:8080/jsonrpc?request="+a)
    try:
        curl.perform()
    except:
        pass
    return render_template('teleco.html')

@app.route('/hdmi/<key>')
def hdmi(key):
    commands={
        'freebox':'tx 4F:82:30:00',
        'rpi':'tx 4F:82:20:00',
        'on':'on 0',
        'standby':'standby 0',
    }
    commande = 'echo "' + commands[key] + '" | cec-client -s -d 1'
    os.system(commande)
    return render_template('teleco.html')
    
@app.route('/Teleco.Teleco.apk')
def static_from_root():
    return send_from_directory(app.static_folder, request.path[1:])

if __name__ == '__main__':
    app.run(threaded=True,debug=True,port=8081,host="0.0.0.0")
