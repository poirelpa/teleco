#! /bin/bash
if [ `ps aux | grep kodi_v7.bin -c` == 1 ]; then su -c kodi-standalone pi; fi
