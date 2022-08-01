import numpy as np
import matplotlib.pyplot as plt
from matplotlib import backend_bases

def plotHeatmap(positions,title):
    
    backend_bases.NavigationToolbar2.toolitems = (
    ('Home', 'Reset original view', 'home', 'home'),
    ('Back', 'Back to  previous view', 'back', 'back'),
    ('Forward', 'Forward to next view', 'forward', 'forward'),
    (None, None, None, None),
    ('Zoom', 'Zoom to rectangle', 'zoom_to_rect', 'zoom'),
    (None, None, None, None),
    ('Save', 'Save the figure', 'filesave', 'save_figure'),)    
    
    fieldx = 16.4846
    fieldy = 8.1026

    spots = np.zeros((6,12),dtype=int)

    positions = [int(x[1:-1]) for x in positions.split(",")]
    for position in positions:
        row = (position // 13)
        column = (position % 12) - 1
        if column == -1:
            column = 11
        spots[row][column] += 1

    fig, ax = plt.subplots()

    am = plt.imread("field_image.png")
    am = ax.imshow(am,extent=[0, fieldx, 0, fieldy])
    im = ax.imshow(spots,alpha=0.4,aspect = "auto",extent=[0, fieldx, 0, fieldy],cmap="Greens")
    plt.axis('scaled')

    ax.set_xticks(np.arange(spots.shape[1]))
    ax.set_xticks((np.arange(spots.shape[1]-1)+1)*(fieldx/spots.shape[1]))
    ax.set_yticks((np.arange(spots.shape[0]-1)+1)*(fieldy/spots.shape[0]))

    ax.grid(color="gray", linestyle='-.', linewidth=1)
    ax.tick_params(which="both", top=False, bottom=False, left=False, right=False)

    threshold = im.norm(spots.max())/2

    # Loop over data dimensions and create text annotations.
    for i in range(spots.shape[0]):
        for j in range(spots.shape[1]):
            color = "white" if int(im.norm(spots[spots.shape[0]-i-1,j])) > threshold else "black"
            text = ax.text(j*(fieldx/spots.shape[1])+(fieldy/spots.shape[0])*0.5, i*(fieldy/spots.shape[0])+(fieldy/spots.shape[0])*.5, spots[spots.shape[0]-i-1, j],
                        ha="center", va="center", color=color, clip_on = True, fontweight = "bold")

    ax.set_title(title, fontweight = "bold")

    fig.canvas.manager.set_window_title(title)
    fig.subplots_adjust(bottom=0.1,left=0.1,right=0.9,top=0.9)
    im.format_cursor_data = lambda e: ""
    plt.show()