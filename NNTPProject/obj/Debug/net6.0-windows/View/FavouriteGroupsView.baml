   M S B A M L   `   `   `  ????F  BNNTPProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NNTPProject.ViewNNTPProject.View  5      *    $NNTPProject.View.FavouriteGroupsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:NNTPProject.View     5      
???????.??5
      ?   ? ColumnDefinitions  5   
   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $??5* ?6   6*   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   .+?5   
   ?? -   5         ??Name$ GroupSearchField??5      $??0??6,   $??0??69   $	??200??6I   $??30??6U   6c   ?? 5   
   -   5         ??Name$ SearchGroupsButton??5      $??0??6-   $??1??6:   $??Search Groups??6J   6?   ?? 5   
   -   5         ??Name$ AllGroupsListView??5      $??1??6.   $??0??6;    ?? View 5      ?? 5      .P?5      ?? $??
All Groups??6%    ?? Width$	 300??69    ?? DisplayMemberBinding 6E   ?? *Header+6o   5      5      ?? 5   
   -   5        $ FavouriteGroupsListView??5      $??1??64   $??1??6A    5      ?? 5       .P?5!      ?? $??Favourite Groups??6%   $	 300??6?    6K   ?? *Header+6u   5"      5$      ?? 5%   
   -   5        $ RefreshAllGroupsButton??5%      $??Refresh All Groups??61   $??2??6N   $??0??6[   
???\\??6?   ?? 5&   
   -   5        $  DeleteFavouriteGroupButton??5&      $??Delete a Favourite Group??65   $??2??6X   $??1??6e   6?   ?? 5'   
   -   5        $ SelectGroup??5'      $??Select a group??6&   $??3??6?   $??0??6L   ??6\   ?? *ChangeArticlesListPageCMD+6?   ?? 5(   
   -   5        $ ViewArticlesButton??5(      $??View Articles??6-   $??3??6E   $??1??6R   ??6b   ?? *ChangeListGroupPageCMD+6?   5)      5*      