class User < ActiveRecord::Base
  before_create :create_remember_token
  validates :Login, presence: true,
                    uniqueness: true,
                    length: { minimum: 1 }
  has_secure_password 
  validates :password, length: { minimum: 6 }
  

  scope :Get, lambda { |login| 
    select(:Login, :Email, :FirstName, :LastName, :ProfileImgPath, :Facebook, 
      :Age, :Sex, :IsPrivate).where(:Login => login)}

  scope :Insert, lambda { |login, password| 
    create(:Login => login, :password => password, :password_confirmation =>password ) }

  scope :UpdatePassword, lambda { |login, new_password|
    update("#{login}", :password => new_password, :password_confirmation => new_password) }  
  
  scope :UpdateLogin, lambda { |login, new_login| 
    where(:Login => login).update_all(:Login => new_login) }  
  
  scope :Delete, lambda { |login| delete(login)}

  scope :UpdateProfile, lambda { |login, email, firstName,lastName, profileImgPath, facebook, age, sex, isPrivate|
    where(:Login => login).update_all(:Email => email,
      :FirstName => firstName, :LastName => lastName, 
      :ProfileImgPath => profileImgPath, :Facebook => facebook, :Age => age,
      :Sex => sex, :IsPrivate => isPrivate ) }

  scope :SearchUsersByName, lambda { |username|
    select(:Login, :Email, :FirstName, :LastName, :ProfileImgPath, 
           :Facebook, :Age, :Sex, :IsPrivate).
    where("FirstName LIKE ? OR LastName LIKE ? OR CONCAT (FirstName,' ', LastName) LIKE ? ",
      "%#{username}%","%#{username}%","%#{username}%") }


  def User.new_remember_token
    SecureRandom.urlsafe_base64
  end

  def User.encrypt(token)
    Digest::SHA1.hexdigest(token.to_s)
  end

  private

    def create_remember_token
      self.remember_token = User.encrypt(User.new_remember_token)
    end
    
end
