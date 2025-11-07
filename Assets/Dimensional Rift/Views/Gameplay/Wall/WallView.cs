using UnityEngine;
using R3;

public class WallView : MonoBehaviour {
    public GameObject[] fragmentPrefabs;
    public Transform wallCenter;
    private WallViewModel viewModel;

    void Awake() {
        var model = new WallModel();
        viewModel = new WallViewModel(model);

        // ReactivePropertyを購読
        viewModel.IsBroken.Subscribe(broken => {
            if (broken) SpawnFragments();
        });
    }

    void SpawnFragments() {
        for (int i = 0; i < 10; i++) {
            var prefab = fragmentPrefabs[Random.Range(0, fragmentPrefabs.Length)];
            var pos = wallCenter.position + Random.insideUnitSphere * 0.3f;
            var rot = Random.rotation;
            var piece = Instantiate(prefab, pos, rot);

            var rb = piece.GetComponent<Rigidbody>();
            rb.AddExplosionForce(300f, wallCenter.position, 2f);
        }
        gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            viewModel.BreakWall();
        }
    }
}
