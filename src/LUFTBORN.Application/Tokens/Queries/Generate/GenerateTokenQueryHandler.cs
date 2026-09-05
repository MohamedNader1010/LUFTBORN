// using ErrorOr;
//
// using LUFTBORN.Application.Authentication.Queries.Login;
// using LUFTBORN.Application.Common.Interfaces;
//
// using MediatR;
//
// namespace LUFTBORN.Application.Tokens.Queries.Generate;
//
// public class GenerateTokenQueryHandler(
//     IJwtTokenGenerator _jwtTokenGenerator)
//         : IRequestHandler<GenerateTokenQuery, ErrorOr<GenerateTokenResult>>
// {
//     public Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenQuery query, CancellationToken cancellationToken)
//     {
//         var id = query.Id ?? Guid.NewGuid();
//
//         var token = _jwtTokenGenerator.GenerateToken(
//             id,
//             query.FirstName,
//             query.LastName,
//             query.Email,
//             query.SubscriptionType,
//             query.Permissions,
//             query.Roles);
//
//         var authResult = new GenerateTokenResult(
//             id,
//             query.FirstName,
//             query.LastName,
//             query.Email,
//             query.SubscriptionType,
//             token);
//
//         return Task.FromResult(ErrorOrFactory.From(authResult));
//     }
// }