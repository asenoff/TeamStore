﻿namespace TeamStore.Keeper.Interfaces
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TeamStore.Keeper.Enums;
    using TeamStore.Keeper.Models;

    public interface IEventService
    {

        Task LogAssetAccessEventAsync(int projectId, int actingUserId, string remoteIpAddress, int assetId);

        Task LogCreateAssetEventAsync(
            int projectId,
            int actingUserId,
            string remoteIpAddress,
            int assetId,
            string assetDescription);

        /// <summary>
        /// Logs a project archive event
        /// </summary>
        /// <param name="projectId">The ID of the project to archive</param>
        /// <param name="actingUserId">The id of the ApplicationUser performing the action</param>
        /// <param name="remoteIpAddress">The IP address of the user calling the action</param>
        /// <returns>A Task result</returns>
        Task LogArchiveProjectEventAsync(int projectId, int actingUserId, string remoteIpAddress);

        /// <summary>
        /// Logs a Sign in event.
        /// </summary>
        /// <param name="identity">The created Claims Identity during sign-ing.</param>
        /// <param name="accessIpAddress">The IP address of the originating request.</param>
        /// <returns>A void Task object</returns>
        Task LogLoginEventAsync(ClaimsIdentity identity, string remoteIpAddress);

        /// <summary>
        /// Logs a Grant Access event
        /// </summary>
        /// <param name="projectId">The Id of the project for which to revoke access.</param>
        /// <param name="remoteIpAddress">The IP address of the originating request.</param>
        /// <param name="newRole">The Role, level of access the identity must have against the project.</param>
        /// <param name="azureAdObjectIdentifier">The Azure AD Object Identifier.</param>
        /// <param name="revokingUser">The ApplicationUser performing the event.</param>
        /// <returns>A Task object</returns>
        Task LogGrantAccessEventAsync(
            int projectId,
            string remoteIpAddress,
            Role newRole,
            int targetUserId,
            int grantingUserId,
            string customData);

        /// <summary>
        /// Logs a Revoke Access event
        /// </summary>
        /// <param name="projectId">The Id of the project for which to revoke access.</param>
        /// <param name="remoteIpAddress">The IP address of the originating request</param>
        /// <param name="azureAdObjectIdentifier">The Azure AD Object Identifier</param>
        /// <param name="revokingUser">The ApplicationUser performing the event</param>
        /// <returns>A Task object</returns>
        Task LogRevokeAccessEventAsync(
            int projectId,
            string remoteIpAddress,
            int targetUserId,
            Role role,
            int revokingUserId,
            string customData);

        /// <summary>
        /// Logs an update to a password. Passwords are not retained in the log.
        /// </summary>
        /// <param name="projectId">The Id of the project for which to update an asset password.</param>
        /// <param name="remoteIpAddress">The IP address of the originating request</param>
        /// <param name="actingUserId">The id of the ApplicationUser performing the action</param>
        /// <param name="assetId">The ID of the asset being updated</param>
        /// <returns></returns>
        Task LogUpdatePasswordEventAsync(int projectId, string remoteIpAddress, int actingUserId, int assetId);

        Task LogUpdateAssetEventAsync(int projectId, string remoteIpAddress, int actingUserId, int assetId);

        Task LogCustomEventAsync(string actingUserId, string customData);
    }
}
