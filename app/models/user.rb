class User < ActiveRecord::Base
  before_create :create_remember_token
  validates :Login, presence: true,
                    uniqueness: true,
                    length: { minimum: 1 }
  validates :password, length: { minimum: 6 }, 
                       on: :create
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

    def validates_params
    # @message=[]
    # if params[:Login].nil? || params[:Login].empty? 
    #   @message += ["Login can't be empty"] 
    # end
    # if params[:Email].nil? || params[:Email].empty? 
    #   params[:Email] = nil
    # else 
    #   begin
    #     if EmailVerifier.check(params[:Email]) == false
    #       @message += ["Email not valid"]
    #     end
    #   rescue Exception => e
    #     @message += ["Email not valid"]
    #   end
    # end
    # if params[:FirstName].nil? || params[:FirstName].empty? 
    #   params[:FirstName] = nil
    # end
    # if params[:LastName].nil? || params[:LastName].empty? 
    #   params[:LastName] = nil
    # end
    # if params[:ProfileImgPath].nil? || params[:ProfileImgPath].empty? 
    #   params[:ProfileImgPath] = nil
    # end
    # if params[:Facebook].nil? || params[:Facebook].empty? 
    #   params[:Facebook] = nil
    # end
    # if params[:Age].nil? || params[:Age].empty? 
    #   params[:Age] = nil
    # else 
    #   params[:Age]=params[:Age].to_i
    #   if params[:Age] <= 0
    #     @message += ["Age mast be numeric or > 0"]
    #   end
    # end
    # if params[:Sex].nil? || params[:Sex].empty? 
    #   params[:Sex] = nil
    # elsif params[:Sex].length>1 || params[:Sex]!= "M" ||
    #       params[:Sex]!= "F" || params[:Sex]!= "N"
    #   params[:Sex] = nil
    # end
    # if params[:IsPrivate].nil? || params[:IsPrivate].empty? 
    #   params[:IsPrivate] = "\x00"
    # elsif params[:IsPrivate] == "true"
    #   params[:IsPrivate] = "\x01"
    # elsif params[:IsPrivate] == "false" 
    #   params[:IsPrivate] = "\x00"
    # else params[:IsPrivate] = "\x00"
    # end
    
    # return(@message)  
    end

    def create_remember_token
      self.remember_token = User.encrypt(User.new_remember_token)
    end
    
end
