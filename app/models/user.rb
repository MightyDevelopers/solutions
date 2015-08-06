class User < ActiveRecord::Base
  before_create :createRememberToken
  validates :Login, presence: true,
                    uniqueness: true,
                    length: { minimum: 1 }
  validates :password, length: { minimum: 6 },
                       on: :create         
  validates :password, presence: { on: :update, allow_blank: true }
  validates_email_realness_of :Email,
                              allow_blank: true
  validates :Age, allow_blank: true,
                  numericality: { only_integer: true },
                  numericality: { greater_than: 1 }
  validates :Sex, allow_blank: true,
                  format: { with: /\A(F|M|N)\z/ }
  has_secure_password

  scope :Get, lambda { |login| 
    select(:Login, :Email, :FirstName, :LastName, :ProfileImgPath, :Facebook, 
      :Age, :Sex, :IsPrivate).where(:Login => login)}

  scope :Insert, lambda { |login, password| 
    create(:Login => login, :password => password, :password_confirmation =>password ) }

  scope :UpdatePassword, lambda { |login, new_password|
    update(login, :password => new_password, :password_confirmation => new_password) }  
  
  scope :UpdateLogin, lambda { |login, new_login| 
    update(login, :Login => new_login) }  
  
  scope :Delete, lambda { |login| delete(login)}

  scope :UpdateProfile, lambda { |login, email, firstName,lastName, profileImgPath, facebook, age, sex, isPrivate|
    update(login, :Email => email,
      :FirstName => firstName, :LastName => lastName, 
      :ProfileImgPath => profileImgPath, :Facebook => facebook, :Age => age,
      :Sex => sex, :IsPrivate => isPrivate ) }

  scope :SearchUsersByName, lambda { |username|
    select(:Login, :Email, :FirstName, :LastName, :ProfileImgPath, 
           :Facebook, :Age, :Sex).
    where("IsPrivate = 'false' AND (FirstName LIKE ? OR LastName LIKE ? OR CONCAT (FirstName,' ', LastName) LIKE ?)",
      "%#{username}%","%#{username}%","%#{username}%") }

  def User.newRememberToken
    SecureRandom.urlsafe_base64
  end

  def User.encrypt(token)
    Digest::SHA1.hexdigest(token.to_s)
  end

  private

    def createRememberToken
      self.remember_token = User.encrypt(User.newRememberToken)
    end
    
end
