class ChangeColumnPassword < ActiveRecord::Migration
  def change
    rename_column :users, :Password, :password_digest
  end
end
