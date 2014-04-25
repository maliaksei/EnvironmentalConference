using Repository.Repositories;

namespace Repository
{
    public class DataManager
    {
        #region Private Members

        private UserRepository _userRepository;

        private RoleRepository _roleRepository;

        private ConferenceRepository _conferenceRepository;

        private KeyDatesRepositories _keyDatesRepositories;

        private ResearchAreasRepository _researchAreasRepository;

        private OrganizingCommitteeMembersRepositories _organizingCommitteeMembersRepositories;

        private OrganizingCommitteeRepositories _organizingCommitteeRepositories;

        private FilesOfConferenceRepositories _filesOfConferenceRepositories;

        private FormOfParticipationRepositories _formOfParticipationRepositories;

        private LanguagesConferenceRepositories _languagesConferenceRepositories;

        private UserReportsRepository _userReportsRepository;

        private ApplicationRepository _applicationRepository;

        #endregion

        #region Public Members

        public UserRepository UserRepository
        {
            get
            {
                return this._userRepository ?? (this._userRepository = new UserRepository());
            }
        }

        public RoleRepository RoleRepository
        {
            get
            {
                return this._roleRepository ?? (this._roleRepository = new RoleRepository());
            }
        }

        public ConferenceRepository ConferenceRepository
        {
            get
            {
                return this._conferenceRepository ?? (this._conferenceRepository = new ConferenceRepository());
            }
        }

        public KeyDatesRepositories KeyDatesRepositories
        {
            get
            {
                return this._keyDatesRepositories ?? (this._keyDatesRepositories = new KeyDatesRepositories());
            }
        }

        public ResearchAreasRepository ResearchAreasRepository
        {
            get
            {
                return this._researchAreasRepository ?? (this._researchAreasRepository = new ResearchAreasRepository());
            }
        }

        public OrganizingCommitteeMembersRepositories OrganizingCommitteeMembersRepositories
        {
            get
            {
                return this._organizingCommitteeMembersRepositories ?? (this._organizingCommitteeMembersRepositories = new OrganizingCommitteeMembersRepositories());
            }
        }

        public OrganizingCommitteeRepositories OrganizingCommitteeRepositories
        {
            get
            {
                return this._organizingCommitteeRepositories ?? (this._organizingCommitteeRepositories = new OrganizingCommitteeRepositories());
            }
        }


        public FilesOfConferenceRepositories FilesOfConferenceRepositories
        {
            get
            {
                return this._filesOfConferenceRepositories ?? (this._filesOfConferenceRepositories = new FilesOfConferenceRepositories());
            }
        }

        public FormOfParticipationRepositories FormOfParticipationRepositories
        {
            get
            {
                return this._formOfParticipationRepositories ?? (this._formOfParticipationRepositories = new FormOfParticipationRepositories());
            }
        }

        public LanguagesConferenceRepositories LanguagesConferenceRepositories
        {
            get
            {
                return this._languagesConferenceRepositories ?? (this._languagesConferenceRepositories = new LanguagesConferenceRepositories());
            }
        }

        public UserReportsRepository UserReportsRepository
        {
            get
            {
                return this._userReportsRepository ?? (this._userReportsRepository = new UserReportsRepository());
            }
        }

        public ApplicationRepository ApplicationRepository
        {
            get
            {
                return this._applicationRepository ?? (this._applicationRepository = new ApplicationRepository());
            }
        }
        #endregion
    }
}
