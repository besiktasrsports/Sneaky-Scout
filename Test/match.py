from gc import callbacks
from subprocess import call
from readJSON import filteredJSONlist
from matplotlib import patches as patches
from matplotlib import pyplot as plt
from matplotlib.widgets import Button
import os
import argparse
import json

matchtypes = {
    "qm": "Qualification Match",
    "qf": "Quarter-Final",
    "sf": "Semi-Final",
    "f": "Final"}

keyToName = {
    "s":"Scouter Initials",
    "e":"Event Name",
    "l":"Match Type",
    "m":"Match Number",
    "r":"Station",
    "t":"Team Number",
    "as":"Auto Start Position",
    "at":"Taxied",
    "au":"Autonomous Upper Cargo Scored",
    "al":"Autonomous Lower Cargo Scored",
    "ac":"Auto Aquired Cargo",
    "tu":"Teleop Upper Cargo Scored",
    "tl":"Teleop Lower Cargo Scored",
    "wd":"Was Defended",
    "wbt":"Wallbot",
    "cif":"Cargo Intake From",
    "ss":"Shooting Spot",
    "c":"Climb",
    "be":"Started Climb Before Endgame",
    "cn":"Number of Robots Climbed",
    "ds":"Driver Skill Level",
    "dr":"Defense Rating Level",
    "hc":"Held Enemy Cargo During Match",
    "sd":"Swerve drive",
    "sr":"Speed Rating",
    "d":"Died/Tipped",
    "all":"Make Good Alliance Partner",
    "co":"Comments",
    "cnf":"Confidence Rating",
    }  

class Index(object):
    def shoot(self, event):
        print("shoot")
    def auto(self, event):
        print("auto")
    def main(self, event):
        print("main")

def plotTable(table_data,title):
    rows = len(table_data)
    cols = 2

    fig, ax = plt.subplots()
    ax.set_ylim(-1, rows-0.45)
    ax.set_xlim(0, 2.6)
    
    for row in range(rows):
        d = table_data[rows-row-1]
        ax.text(x=0.45, y=row, s=d[0], va='center', ha='center')
        ax.text(x=0.9, y=row, s=d[1], va='center', ha='left')

    for row in range(rows+1):
        ax.plot(
            [0.1, 2.5],
            [row - 0.45, row - 0.45],
            ls='-',
            lw='0.75',
            c='grey'
        )
    
    ax.plot([0.8, 0.8],[-0.45, rows-0.45],ls='-',lw='0.75',c='grey')
    ax.plot([0.1, 0.1],[-0.45, rows-0.45],ls='-',lw='0.75',c='grey')
    ax.plot([2.5, 2.5],[-0.45, rows-0.45],ls='-',lw='0.75',c='grey')

    for row in range((rows+1)//2):
        rect = patches.Rectangle(
            (0.1, -0.45+(row)*2), # bottom left starting position (x,y)
            2.4, # width
            1, # height
            ec="none",
            fc="green",
            alpha=.2,
            zorder=-1
        )
        ax.add_patch(rect)

    ax.axis("off")
    ax.set_title(title,	loc="center", weight="bold")
    
    fig.canvas.manager.set_window_title(title)
    plt.subplots_adjust(bottom=0.07,left=0.0,right=1,top=0.95)
    
    callback = Index()
    axes = plt.axes([0.8115, 0.01, 0.15, 0.075])
    bshoot = Button(axes, 'Shooting Spots')
    bshoot.on_clicked(callback.shoot)

    axes = plt.axes([0.65, 0.01, 0.15, 0.075])
    bauto = Button(axes, 'Auto Position')
    bauto.on_clicked(callback.auto)

    axes = plt.axes([0.4885, 0.01, 0.15, 0.075])
    bmain = Button(axes, 'Main Table')
    bmain.on_clicked(callback.main)

    plt.show()

parser = argparse.ArgumentParser()
#parser.add_argument("-tn","--team_number", type=int, required=True)
#parser.add_argument("-mn","--match_number", type=int, required=True)
#parser.add_argument("-mt","--match_type", type=str, required=True)
#parser.add_argument("-d","--directory", type=str, required=True)

args = parser.parse_args()
dir = os.getcwd()

#matchlist = filteredJSONlist(dir + "\\matches",args.match_type,args.team_number,args.match_number)
matchlist = filteredJSONlist(dir + "\\matches","qm",7285,2)
data = ""

if len(matchlist) == 1:
    f = open(dir + f"\\matches\\{matchlist[0]}")
    data = json.load(f)
    f.close()

if data:
    result = list(data.items())
    tableData = [[keyToName[x[0]],x[1]] if x[0] in keyToName.keys() else [x[0],x[1]] for x in result]
    title = "Team {team_number} {match_type} {match_number}".format(team_number = data["t"], match_type = matchtypes[data["l"]],match_number = data["m"])
    plotTable(tableData,title)