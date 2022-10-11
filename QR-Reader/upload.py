import os
import sys
import gspread
import json
from oauth2client.service_account import ServiceAccountCredentials


scope = [
    "https://www.googleapis.com/auth/spreadsheets",
    "https://www.googleapis.com/auth/drive",
]

credentials = ServiceAccountCredentials.from_json_keyfile_name(
    "gs_credentials.json", scope
)
client = gspread.authorize(credentials)

sht = client.open_by_url(
    "https://docs.google.com/spreadsheets/d/13Spr4SYjp9jOIBUEsrjkP7Q7qiWvQODBS4qp3W9w7So"
)

worksheet = sht.worksheet("Database")
folder = sys.path[0] + "\\ScoutDatas"

try:
    os.path.exists(folder)
except:
    print("No ScoutDatas Folder")
    sys.exit()

matches = os.listdir(folder)

rows = worksheet.get_all_values()
lengthOfRows = len(rows)
totalRows = worksheet.row_count

emptyRow = lengthOfRows + 1
uploadCounter = 0

emptyRowList = [""] * 26
climbDict = {
    "1": 4,
    "2": 6,
    "3": 10,
    "4": 15,
    "a": 0,
    "x": 0
}

for match in matches:
    values = []
    f = open(folder + "\\" + match)
    data = json.load(f)
    keys = list(data)
    for key in keys:
        if(key in ["at","wd","wbt","be","hc","sd","d"]):
            if(data[key] == "Y"):
                values.append(1)
            else:
                values.append(0)
        else:
            values.append(data[key])
    values.append(len(values[15][1:-1].split(",")))
    values.append(climbDict[values[16]])
    for rowNumber in range(lengthOfRows):
        if (
            rows[rowNumber][2] == values[2]
            and rows[rowNumber][3] == values[3]
            and rows[rowNumber][5] == values[5]
        ):
            break

    else:
        worksheet.update("A" + str(emptyRow), [values], value_input_option='USER_ENTERED')
        emptyRow += 1
        uploadCounter += 1

rows = worksheet.get_all_values()
lengthOfRows = len(rows)
deleteCounter = 0

for rowNumber in range(lengthOfRows):
    if rows[rowNumber] == emptyRowList:
        worksheet.delete_rows(rowNumber + 1 - deleteCounter)
        deleteCounter += 1

worksheet.add_rows(worksheet.row_count - totalRows)

print("Uploaded " + str(uploadCounter) + " New Matches to Google SpreadSheets")
print("Deleted " + str(deleteCounter) + " Empty Rows")