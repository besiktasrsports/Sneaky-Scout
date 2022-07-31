import numpy as np
import matplotlib
import matplotlib.pyplot as plt
from matplotlib import backend_bases
def plotHeatmap():

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
    am = ax.imshow(am,extent=[0, 16.5, 0, 8.1])
    im = ax.imshow(spots,alpha=0.5,aspect = "auto",extent=[0, 16.5, 0, 8.1],cmap="Blues")
    plt.axis('scaled')

    ax.set_xticks(np.arange(spots.shape[1]))
    ax.set_xticks((np.arange(spots.shape[1]-1)+1)*1.375)
    ax.set_yticks((np.arange(spots.shape[0]-1)+1)*1.35)
    ax.grid(color="black", linestyle='-.', linewidth=1)
    
    ax.tick_params(which="minor", bottom=True, left=True)

    threshold = im.norm(spots.max())/2
    print(spots)
    # Loop over data dimensions and create text annotations.
    for i in range(spots.shape[0]):
        for j in range(spots.shape[1]):
            color = "black" if int(im.norm(spots[spots.shape[0]-i-1,j])) < threshold else "white"
            text = ax.text(j*1.375+0.6875, i*1.35+0.675, spots[spots.shape[0]-i-1, j],
                        ha="center", va="center", color=color)

    ax.set_title("Team 7285 Qualification Match 2 Shooting Spots")
    fig.tight_layout()
    plt.show()
plotHeatmap()