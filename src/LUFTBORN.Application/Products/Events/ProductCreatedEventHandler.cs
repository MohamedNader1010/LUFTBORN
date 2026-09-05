using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Domain.Products.Events;

using MediatR;

namespace LUFTBORN.Application.Products.Events;

public class ProductCreatedEventHandler(
    IEmailService emailService) : INotificationHandler<ProductCreatedEvent>
{
    public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        var product = notification.Product;
        


        var emailBody = $"""
                         Hello,

                         Your product has been created successfully.

                         Product: {product.Name}
                         Price: {product.Price}

                         Thank you.
                         """;

        await emailService.SendAsync(
            "string",
            "Product Created Successfully",
            emailBody,
            cancellationToken);
    }
}