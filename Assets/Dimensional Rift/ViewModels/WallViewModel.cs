using UnityEngine;
using R3;

public class WallViewModel {
    private WallModel model;
    public ReactiveProperty<bool> IsBroken => model.IsBroken;

    public WallViewModel(WallModel model) {
        this.model = model;
    }

    public void BreakWall() {
        model.IsBroken.Value = true;
    }
}

