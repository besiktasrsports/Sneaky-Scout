import json
import os

def filteredJSONlist(directory: str, match_type: str = None, team_number: int = None, match_number: int = None):
    matches = os.listdir(directory)
    for match in range(len(matches)):
        if match_type:
            if matches[match].split("_")[0] != match_type:
                matches[match] = None
                continue
        if team_number:
            if int(matches[match].split("_")[2][:len(str(team_number))]) != team_number:
                matches[match] = None
                continue
        if match_number:
            if int(matches[match].split("_")[1]) != match_number:
                matches[match] = None
                continue
    final = [x for x in matches if x != None]
    return(final)