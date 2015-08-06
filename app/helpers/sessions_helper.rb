module SessionsHelper

  def createSession(user)
    remember_token = User.newRememberToken
    cookies.permanent[:remember_token] = remember_token
    user.update_attribute(:remember_token, User.encrypt(remember_token))
    self.currentUser = user
  end

  def signedIn?
    !currentUser.nil?      
  end

  def currentUser=(user)
      @currentUser = user
  end

  def currentUser
    remember_token = User.encrypt(cookies[:remember_token])      
    @currentUser ||= User.find_by(remember_token: remember_token) 
  end

  def currentUser?(user)
    user == currentUser
  end

  def isAuthorize?
    unless signedIn? 
      massege = ["Before sign in"]
      render json: { :errors => massege }, :status => "#{massege}"
    end 
  end

  def destroySession
    currentUser.update_attribute(:remember_token,
                                  User.encrypt(User.newRememberToken))
    cookies.delete(:remember_token)
    self.currentUser = nil
  end

end
