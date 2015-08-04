class UsersController < ApplicationController
  before_action :signed_in_user, only: [:updateProfile, :changeLogin, :changePassword, :deleteUser]
  before_action :correct_user, only: [:updateProfile, :changeLogin, :changePassword, :deleteUser]

  respond_to :json

  def createUser
    @user = User.Insert(params[:Login],params[:Password])
    if @user.valid?
      sign_in @user
      @user = User.Get(params[:Login]).first
      json_return(@user)
    else 
      json_error_return(@user.errors.full_messages)
    end
  end

  def getUser
    begin 
      @user = User.find(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user=User.Get(params[:Login]).first
        sign_in @user
        json_return(@user)
      else
        json_error_return("Can't find this user") 
      end 
    rescue => e 
      json_error_return(e.message)
    end
  end

  def updateProfile
    begin
      @user = User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                    params[:LastName],params[:ProfileImgPath],params[:Facebook],
                    params[:Age],params[:Sex],params[:IsPrivate])
      if @user.valid?
        json_return(@user)  
      else 
        json_error_return(@user.errors.full_messages)  
      end
    rescue => e
      json_error_return(e.message)
    end
  end

  def changeLogin  
    begin   
      @user = User.find_by_Login(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user =  User.UpdateLogin(params[:Login],params[:New_login])
        if @user.valid?
          sign_in @user
          @user = User.Get(params[:New_login]).first
          json_return(@user)    
        else
          json_error_return(@user.errors.full_messages)    
        end
      else 
        @message = ["Somesing wrong(maybe login/password/new_login is invalid)"]    
        json_return(@message)    
      end
    rescue => e
      json_error_return(e.message)
    end
  end

  def changePassword
    begin
      @user = User.find_by_Login(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user = User.UpdatePassword(params[:Login],params[:New_password])
        if @user.valid?
          @user = User.Get(params[:Login]).first
          json_return(@user)    
        else
          json_error_return(@user.errors.full_messages)    
        end
      else
        @message = ["Somesing wrong(maybe login/password/new_password is invalid)"]
        json_error_return(@message)
      end
    rescue Exception => e
      json_error_return(e.message)
    end
  end

  def deleteUser
    @user = User.find_by_Login(params[:Login])
    if @user && @user.authenticate(params[:Password])
      User.Delete(params[:Login])
      @user = ["Deleted"]
      json_return(@user)
    else 
      @message = ["Somesing wrong(maybe login/password is invalid)"]
      json_error_return(@message)
    end
  end

  def searchByName
    @user = User.SearchUsersByName(params[:Username])
    if @user.empty?
      @message = ["Can't find users whith this params"]
      json_error_return(@message)
    else
      json_return(@user)  
    end
  end

  private

  def correct_user
    @user = User.find_by_Login(params[:Login])
    json_error_return(["Somesing wrong(Please sign in whith this params)"]) unless current_user?(@user)
  end

  def json_return(param)
    render json: param
  end

  def json_error_return(param)
    render json: { :errors => param }, :status => "#{param}"
  end

end
