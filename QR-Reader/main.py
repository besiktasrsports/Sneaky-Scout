import cv2
import numpy as np
from pyzbar.pyzbar import decode, ZBarSymbol
import argparse
import json
import sys
import os
import playsound


def sucessAlert():
    playsound.playsound(path + f"\\resources\\sucess.wav", False)


def qrToJson(myData):
    DataStream = myData.split(";")
    FinalDataStream = [i.split("=") for i in DataStream]
    final = {sub[0]: sub[1] for sub in FinalDataStream}
    try:
        f = open(
            path
            + f"\\ScoutDatas\\{final['l']}_{final['m']}_{final['t']}.json",
            "w",
        )
    except:
        os.mkdir(path + "\\ScoutDatas")
        f = open(
            path
            + f"\\ScoutDatas\\{final['l']}_{final['m']}_{final['t']}.json",
            "w",
        )
    json.dump(final, f, indent=4)
    f.close()


ap = argparse.ArgumentParser()
ap.add_argument("-c", "--camera", required=False, help="Camera Number", default=0)
args = ap.parse_args()


def videoCaptureSetCamera(cap, height, width):
    cap.set(4, height)
    cap.set(3, width)


cap = cv2.VideoCapture(int(args.camera))
videoCaptureSetCamera(cap, 640, 480)

path = sys.path[0]
readQR = True
myData = ""

if not os.path.exists(path + "\\ScoutDatas"):
    os.mkdir(path + "\\ScoutDatas")

while readQR:
    _, img = cap.read()
    decoded = decode(img, symbols=[ZBarSymbol.QRCODE])

    if decoded and len(decoded) == 1:
        color = (0, 255, 0)
        barcode = decoded[0]
        myOldData = myData
        myData = barcode.data.decode("utf-8")
        pts = np.array([barcode.polygon], np.int32)
        pts2 = barcode.rect

        if myOldData != myData and myData[0:2] == "s=":
            qrToJson(myData)
            sucessAlert()
            color = (0, 0, 255)

        cv2.polylines(img, [pts], True, color, 5)

    img = cv2.flip(img, 1)
    cv2.imshow("Sneaky Scanner", img)

    if cv2.waitKey(1) == ord("q"):
        readQR = False
