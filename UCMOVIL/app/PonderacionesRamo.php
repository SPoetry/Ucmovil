<?php

namespace App;

use Illuminate\Database\Eloquent\Model;


class PonderacionesRamo extends Model
{
  public $incrementing = false;
  protected $primaryKey = ['id_ramo','N_nota'];
  protected $fillable = [
      'id_ramo', 'N_nota', 'P_nota',
  ];

  public function versionramo(){
    return $this->belongTo(VersionRamo::class, 'id_ramo', 'id_ramo');
  }
}
