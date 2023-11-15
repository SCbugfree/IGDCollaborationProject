using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Linesmanage
{
    public string UpdateDialogues();
    public string CurrentLines { get; set; }
    public int LinesCount { get; set; }
    public void EnterDialogue();
}
