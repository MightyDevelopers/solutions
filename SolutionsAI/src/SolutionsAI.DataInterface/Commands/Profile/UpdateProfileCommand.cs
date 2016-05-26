using System;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.Profile
{
    public class UpdateProfileCommand: BaseCommand<Domain.Profile, Domain.Profile>
    {
        private readonly GetProfileByEmailCommand _getProfileByEmailCommand;
        private Domain.Profile _profile;

        public UpdateProfileCommand(
            IRepository<Domain.Profile> repository, 
            GetProfileByEmailCommand getProfileByEmailCommand) : base(repository)
        {
            _getProfileByEmailCommand = getProfileByEmailCommand;
        }

        public void Init(Domain.Profile profile)
        {
            BeginInit();
            _profile = profile;
            EndInit();
        }

        protected override string Name => "UpdateProfileCommand";
        public override void Execute()
        {
            HandleExecute(() =>
            {
                var updated = Repository.HasAffect("UpdateProfile",
                    Repository.GetDataParameter("email", _profile.EMail),
                    Repository.GetDataParameter("firstName", _profile.FirstName),
                    Repository.GetDataParameter("lastName", _profile.LastName),
                    Repository.GetDataParameter("lastUpdateDate", DateTime.UtcNow));

                if (updated)
                {
                    _getProfileByEmailCommand.Init(_profile.EMail);
                    var result =  _getProfileByEmailCommand.GetResult();
                    if (result.State == CommandResultState.Success)
                    {
                        return result.Result;
                    }
                    throw result.Error.Exception;
                }
                throw new MissingFieldException("Profile not found");
            });
        }
    }
}
