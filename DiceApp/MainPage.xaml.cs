namespace DiceApp;

public partial class MainPage : ContentPage
{

    Random Random { get; set; } = new Random();

    public bool FlipAdvantage
    {
        get
        {
            return chkFlipAdv.IsChecked;
        }
    }
    public bool RollAdvantage
    {
        get
        {
            return chkRollAdv.IsChecked;
        }
    }

    public MainPage()
    {
        InitializeComponent();
        imgMain.IsAnimationPlaying = false;
    }

    private void btnCoin_Clicked(object sender, EventArgs e)
    {
        int result = Random.Next(2);

        if (result == 0)
        {
            //tails
            lblFlip.Text = "Tails";
        }
        else if (result == 1)
        {
            //heads
            lblFlip.Text = "Heads";
        }

        if (FlipAdvantage)
        {
            result = Random.Next(2);

            if (result == 0)
            {
                //tails
                lblFlip.Text += ", Tails";
            }
            else if (result == 1)
            {
                //heads
                lblFlip.Text += ", Heads";
            }
        }

        result = Random.Next(2);
        imgMain.IsAnimationPlaying = (result == 0);
    }

    private void btnCoinTillLose_Clicked(object sender, EventArgs e)
    {
        int wins = 0;
        bool won = true;
        int result;

        while (won)
        {
            result = Random.Next(2);

            if (result == 0)
            {
                wins++;
            }
            else
            {
                if (FlipAdvantage)
                {

                    result = Random.Next(2);
                    if (result == 0)
                    {
                        wins++;
                    }
                    else
                    {
                        won = false;
                    }
                }
                else
                {
                    won = false;
                }

            }

        }

        lblFlip.Text = $"Won: {wins.ToString()}";
    }


    private void btnDice_Clicked(object sender, EventArgs e)
    {
        int result = Random.Next(1, 21);

        lblRoll.Text = result.ToString();

        if (RollAdvantage)
        {
            result = Random.Next(1, 21);

            lblRoll.Text += ", " + result.ToString();
        }
    }

    private void btnDiceTillLose_Clicked(object sender, EventArgs e)
    {
        int wins = 0;
        bool won = true;
        int result;

        while (won)
        {
            result = Random.Next(1, 21);

            if (result >= 15)
            {
                wins++;
            }
            else
            {
                if (RollAdvantage)
                {
                    result = Random.Next(1, 21);

                    if (result >= 15)
                    {
                        wins++;
                    }
                    else
                    {
                        won = false;
                    }
                }
                else
                {
                    won = false;
                }

            }

        }

        lblRoll.Text = $"Won: {wins.ToString()}";
    }
}

