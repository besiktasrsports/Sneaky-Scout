from readJSON import filteredJSONlist
from matplotlib import patches as patches
from matplotlib import pyplot as plt
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
            lw='.5',
            c='grey'
        )
    
    ax.plot([0.8, 0.8],[-0.45, rows-0.45],ls='-',lw='.5',c='grey')
    ax.plot([0.1, 0.1],[-0.45, rows-0.45],ls='-',lw='.5',c='grey')
    ax.plot([2.5, 2.5],[-0.45, rows-0.45],ls='-',lw='.5',c='grey')

    rect = patches.Rectangle(
        (0.1, -0.45),
        .7,
        rows,
        ec='none',
        fc='grey',
        alpha=.2,
        zorder=-1
    )
    ax.add_patch(rect)
    ax.axis("off")
    ax.set_title(title,	loc='center', weight='bold')
    
    fig.canvas.manager.set_window_title(title)
    plt.subplots_adjust(bottom=0.0,left=0.0,right=1,top=0.95)
    plt.show()

parser = argparse.ArgumentParser()
parser.add_argument("-tn","--team_number", type=int, required=True)
parser.add_argument("-mn","--match_number", type=int, required=True)
parser.add_argument("-mt","--match_type", type=str, required=True)
#parser.add_argument("-d","--directory", type=str, required=True)

args = parser.parse_args()
dir = os.getcwd()

matchlist = filteredJSONlist(dir + "\\matches",args.match_type,args.team_number,args.match_number)
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