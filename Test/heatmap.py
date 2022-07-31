import numpy as np
import matplotlib
import matplotlib.pyplot as plt
from matplotlib import backend_bases

def plotHeatmap():
    fieldx = 16.4846
    fieldy = 8.1026
    backend_bases.NavigationToolbar2.toolitems = (
        ('Home', 'Reset original view', 'home', 'home'),
        ('Back', 'Back to  previous view', 'back', 'back'),
        ('Forward', 'Forward to next view', 'forward', 'forward'),
        (None, None, None, None),
        ('Zoom', 'Zoom to rectangle', 'zoom_to_rect', 'zoom'),
        (None, None, None, None),
        ('Save', 'Save the figure', 'filesave', 'save_figure'),
      )
    
    spots = np.random.randint(10,size=(6,12))

    fig, ax = plt.subplots()

    am = plt.imread("field_image.png")
    am = ax.imshow(am,extent=[0, fieldx, 0, fieldy])
    im = ax.imshow(spots,alpha=0.5,aspect = "auto",extent=[0, fieldx, 0, fieldy],cmap="Blues")
    plt.axis('scaled')

    ax.set_xticks(np.arange(spots.shape[1]))
    ax.set_xticks((np.arange(spots.shape[1]-1)+1)*(fieldx/spots.shape[1]))
    ax.set_yticks((np.arange(spots.shape[0]-1)+1)*(fieldy/spots.shape[0]))
    ax.grid(color="black", linestyle='-.', linewidth=1)
    
    ax.tick_params(which="minor", bottom=True, left=True)

    threshold = im.norm(spots.max())/2
    print(spots)
    # Loop over data dimensions and create text annotations.
    for i in range(spots.shape[0]):
        for j in range(spots.shape[1]):
            color = "white" if int(im.norm(spots[spots.shape[0]-i-1,j])) > threshold else "black"
            text = ax.text(j*(fieldx/spots.shape[1])+(fieldy/spots.shape[0])*0.5, i*(fieldy/spots.shape[0])+(fieldy/spots.shape[0])*.5, spots[spots.shape[0]-i-1, j],
                        ha="center", va="center", color=color)

    ax.set_title("Team 7285 Qualification Match 2 Shooting Spots")
    fig.tight_layout()
    plt.show()
plotHeatmap()