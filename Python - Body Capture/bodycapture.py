import cv2
from cvzone.PoseModule import PoseDetector
import socket

width, height = 780, 520

cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)

detector = PoseDetector()

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    success, img = cap.read()
    img = detector.findPose(img)
    lmList, bboxInfo = detector.findPosition(img)

    posList = []

    if bboxInfo:
        lmString = ''
        for lm in lmList:
            print(lm)
            lmString += f'{lm[0]},{img.shape[0] - lm[1]},{lm[2]},'
        posList.append(lmString)
        sock.sendto(str.encode(str(posList)), serverAddressPort)

    print(posList)

    cv2.imshow('img', img)
    cv2.waitKey(1)