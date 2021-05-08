using System;

using AutofacDependencyInjection.Domain;

using UIKit;

namespace AutofacDependencyInjection.Touch
{
    public partial class SecondViewController : UIViewController
    {
        private readonly MessageService messageService;

        public SecondViewController(MessageService messageService) : base("SecondViewController", null)
        {
            this.messageService = messageService;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            messageService.SaveMessage("Hola");
        }
    }
}

