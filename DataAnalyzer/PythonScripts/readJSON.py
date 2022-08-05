import json
import os

def filteredJSONlist(directory: str, match_type: str = None, team_number: int = None, match_number: int = None):
    try:
        matches = os.listdir(directory + f"\\{match_type}")
    except:
        matches = []
    for match in range(len(matches)):
        if team_number:
            if matches[match].split("_")[2][:len(str(team_number))] != str(team_number):
                matches[match] = None
                continue
        if match_number:
            if int(matches[match].split("_")[1]) != match_number:
                matches[match] = None
                continue
    final = [x for x in matches if x != None]
    return(final)