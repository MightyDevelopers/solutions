class UsersController < ApplicationController
  before_action :isAuthorize?, only: [:updateProfile, :changeLogin, :changePassword, :deleteUser]
  before_action :correctUser, only: [:updateProfile, :changeLogin, :changePassword, :deleteUser]

  respond_to :json

  def createUser
    @user = User.Insert(params[:Login],params[:Password])
    if @user.valid?
      createSession @user
      @user = User.Get(params[:Login]).first
      jsonReturn(@user)
    else 
      jsonErrorReturn(@user.errors.full_messages)
    end
  end

  def getUser
    begin 
      @user = User.find(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user=User.Get(params[:Login]).first
        createSession @user
        jsonReturn(@user)
      else
        jsonErrorReturn("Couldn't find this User") 
      end 
    rescue => e 
      jsonErrorReturn("Couldn't find this User")
    end
  end

  def updateProfile
    begin
      @user = User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                    params[:LastName],params[:ProfileImgPath],params[:Facebook],
                    params[:Age],params[:Sex],params[:IsPrivate])
      if @user.valid?
        @user = User.Get(params[:Login]).first
        jsonReturn(@user)  
      else 
        jsonErrorReturn(@user.errors.full_messages)  
      end
    rescue => e
      jsonErrorReturn("Some params not valid")
    end
  end

  def changeLogin  
    begin   
      @user = User.find_by_Login(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user = User.UpdateLogin(params[:Login], params[:New_login])
        if @user.valid?
          createSession @user
          @user = User.Get(params[:New_login]).first
          jsonReturn(@user)    
        else
          jsonErrorReturn(@user.errors.full_messages)    
        end
      else 
        @message = ["Somesing wrong(maybe login/password/new_login is invalid)"]    
        jsonReturn(@message)    
      end
    rescue => e
      jsonErrorReturn(e.message)
    end
  end

  def changePassword
    begin
      @user = User.find_by_Login(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user = User.UpdatePassword(params[:Login],params[:New_password])
        if @user.valid?
          @user = User.Get(params[:Login]).first
          jsonReturn(@user)    
        else
          jsonErrorReturn(@user.errors.full_messages)    
        end
      else
        @message = ["Somesing wrong(maybe login/password/new_password is invalid)"]
        jsonErrorReturn(@message)
      end
    rescue Exception => e
      jsonErrorReturn(e.message)
    end
  end

  def deleteUser
    @user = User.find_by_Login(params[:Login])
    if @user && @user.authenticate(params[:Password])
      User.Delete(params[:Login])
      @user = ["User deleted. End of session"]
      destroySession
      jsonReturn(@user)
    else 
      @message = ["Somesing wrong(maybe login/password is invalid)"]
      jsonErrorReturn(@message)
    end
  end

  def searchByName
    @user = User.SearchUsersByName(params[:Username])
    if @user.empty?
      @message = ["Can't find users whith this params"]
      jsonErrorReturn(@message)
    else
      jsonReturn(@user)  
    end
  end

  private

  def correctUser
    @user = User.find_by_Login(params[:Login])
    jsonErrorReturn(["Somesing wrong"]) unless currentUser?(@user)
  end

  def jsonReturn(data)
    render json: data
  end

  def jsonErrorReturn(param)
    render json: { :errors => param }, :status => "#{param}"
  end

end
