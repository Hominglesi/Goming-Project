using System;

public interface IBossStage
{
    public void OnAwake();
    public void Update();
    public void SetActive(bool active);
}

