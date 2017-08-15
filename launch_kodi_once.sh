#! /bin/bash
if [ `ps aux | grep kodi.bin -c` == 1 ]; then su -c kodi-standalone pi; fi
