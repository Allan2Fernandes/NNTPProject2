   M S B A M L   `   `   `  ????F  BNNTPProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NNTPProject.ViewNNTPProject.View  5      &     NNTPProject.View.PostArticleView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:NNTPProject.View     5      
???????.??5
      ?   ? ColumnDefinitions  5   
    ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??5* ?6   6*   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   .+?5   
   ?? $??From:??6   $??50??6    $??30??6+   $??	0,0,200,0q?67   $??0??6J   6Y   ?? 5   
   -   5         ??Name$ NameTextBox??5      $??0??6'   $??Allan Fernandes??64   $	??100??6K   $??30??6W   ?? 5   
   $??Subject:??6   $??50??6#   $??30??6.   $??	0,0,200,0q?6:   $??1??6M   6\   ?? 5   
   -   5        $ SubjectTextBox??5      $??1??6*   $?? ??67   $	??200??6?   $??30??6K   $??200,0,100,0q?6W   ?? 5   
   $??Selected NewsGroup: ??6   $??2??6/   $	??130??6<   $??30??6H   $??	0,0,120,0q?6T   ?? 5   
   -   5        $ SelectedNewsGroup??5      $??2??6-   $??30??6:   $	??200??6F   $??	200,0,0,0q?6R   ??6e   ?? *SelectedNewsGroup+?? 5   
   -   5        $ BodyTextBox??5      $??3??6'   66   ?? 5   
   -   5         ??Name$ 
PostButton??5      $??4??6%   $??Post!??62   $	??100??6B   $??30??6N   $??	0,0,200,0q?6Z   6m   ?? 5   
   -   5        $ ReturnButton??5      $??4??6'   $??Return!??64   $	??100??6F   $??30??6R   $??	200,0,0,0q?6^   ??6q   ?? *ChangePageCMD+6?   ?? 5   
   -   5         ??Name$ ServerResponseLabel??5      $??5??6.   $??Server Response:??6;   6X   5       5!      